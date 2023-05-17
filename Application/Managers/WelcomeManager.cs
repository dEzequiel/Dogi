using Application.DTOs.WelcomeManager;
using Application.Features.IndividualPro.Commands;
using Application.Features.InsertAnimalChipRequest.Commands;
using Application.Features.ReceptionDocument.Commands;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Managers
{
    public class WelcomeManager : IWelcomeManager
    {
        private readonly ILogger<WelcomeManager> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
        public WelcomeManager(IMediator mediator ,IUnitOfWork unitOfWork, ILogger<WelcomeManager> logger)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public WelcomeManager() { }

        /// <summary>
        /// Add a new reception document taking into account whether the animal has a chip or not. With this condition you take one way or the other.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="adminData"></param>
        /// <returns>An object where the information of the reception document and the information of the chip can be consulted together with that of the owner.</returns>
        public async Task<RegisterInformation> AddAnimalWithOwnerInfo(ReceptionDocumentWithAnimalInformation data, AdminData adminData)
        {
            if(!data.ReceptionDocument.HasChip)
            {
               var result = await AddReceptionDocumentInformation(data, adminData);
               return new RegisterInformation(result.ReceptionDocument, result.IndividualProceeding);
            } else
            {
                var result = await AddReceptionDocumentWithAnimalChipOwnerInformation(data, adminData);
                return new RegisterInformation(result.ReceptionDocument, result.AnimalChip);
            }
        }

        private async Task<ReceptionDocumentWithIndividualProceeding> AddReceptionDocumentInformation(ReceptionDocumentWithAnimalInformation data, AdminData adminData)
        {
            var receptionDocumentRequest = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
            
            data.IndividualProceeding!.ReceptionDocumentId = receptionDocumentRequest.Data.Id;

            AssignQuarantineZoneToNewHost(data);
            
            var individualProceeding = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));

            return new ReceptionDocumentWithIndividualProceeding()
            {
                ReceptionDocument = receptionDocumentRequest.Data,
                IndividualProceeding = individualProceeding.Data,
            };
        }

        private async Task<ReceptionDocumentWithAnimalInformation> AddReceptionDocumentWithAnimalChipOwnerInformation(ReceptionDocumentWithAnimalInformation data, AdminData adminData)
        {
            try 
            {
                var receptionDocumentEntity = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
                var animalChipEntity = await _mediator.Send(new InsertAnimalChipRequest(data.AnimalChip!, adminData));
                var individualProceedingEntity = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));

                return new ReceptionDocumentWithAnimalInformation()
                {
                    ReceptionDocument = receptionDocumentEntity.Data,
                    AnimalChip = animalChipEntity.Data,
                    IndividualProceeding = individualProceedingEntity.Data
                };

            } catch(Exception ex) 
            {
                _logger.LogInformation("WelcomeManager --> AddReceptionDocumentWithAnimalChipOwnerInformation --> Catch Exception");
                throw new DogiException("Something went wrong when registering new information");
            }            
       }
    
        private void AssignQuarantineZoneToNewHost(ReceptionDocumentWithAnimalInformation data) {
            
            var AnimalZoneRepository = _unitOfWork.AnimalZoneRepository.GetQueryableAsync();

            var animalZone =  AnimalZoneRepository.FirstOrDefault(x => x.Id == (int)AnimalZone.Quarantine);

            data.IndividualProceeding!.ZoneId = ((int)AnimalZone.Quarantine);
            data.IndividualProceeding!.AnimalZone = animalZone!;
        
        }

        ///<inheritdoc />
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
