using Application.DTOs.WelcomeManager;
using Application.Features.IndividualPro.Commands;
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
        private ILogger<WelcomeManager> _logger;
        private IAnimalChipWrite _animalChipWrite;
        private IIndividualProceedingWrite _individualProceedingWrite;
        private IMediator _mediator;
        private IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="animalChipOwnerWrite"></param>
        /// <param name="receptionDocumentWrite"></param>
        /// <param name="animalChipWrite"></param>
        public WelcomeManager(IAnimalChipWrite? animalChipWrite, IIndividualProceedingWrite individualProceedingWrite,IMediator mediator ,IUnitOfWork unitOfWork, ILogger<WelcomeManager> logger)
        {
            _animalChipWrite = animalChipWrite;
            _individualProceedingWrite = individualProceedingWrite;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

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
            //var receptionDocument = await _receptionDocumentWrite.AddAsync(data.ReceptionDocument, adminData);
            var receptionDocumentRequest = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
            if(!receptionDocumentRequest.Succeeded)
            {
                throw new DogiException("Error when trying to insert the reception document."); 
            }
            
            Guard.Against.Null(receptionDocumentRequest.Data, nameof(receptionDocumentRequest.Data));

            var receptionDocument = receptionDocumentRequest.Data;
            data.IndividualProceeding!.ReceptionDocumentId = receptionDocument.Id;

            AssignQuarantineZoneToNewHost(data);
            
            var individualProceeding = await _individualProceedingWrite.AddAsync(data.IndividualProceeding!, adminData);
            // var individualProceeding = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));
            // if(!individualProceeding.Succeeded)
            // {
            //     throw new DogiException("Error when trying to insert the individual proceeding."); 
            // }

            return new ReceptionDocumentWithIndividualProceeding()
            {
                ReceptionDocument = receptionDocument,
                //IndividualProceeding = individualProceeding.Data,
                IndividualProceeding = individualProceeding,
            };
        }

        private async Task<ReceptionDocumentWithAnimalInformation> AddReceptionDocumentWithAnimalChipOwnerInformation(ReceptionDocumentWithAnimalInformation data, AdminData adminData)
        {
            try 
            {
                var receptionDocumentEntity = await _mediator.Send(new InsertReceptionDocumentRequest(data.ReceptionDocument, adminData));
                var animalChipEntity = await _animalChipWrite.AddAsync(data.AnimalChip!, adminData);
                var individualProceedingEntity = await _mediator.Send(new InsertIndividualProceedingRequest(data.IndividualProceeding, adminData));

                return new ReceptionDocumentWithAnimalInformation()
                {
                    ReceptionDocument = receptionDocumentEntity.Data,
                    AnimalChip = animalChipEntity,
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
