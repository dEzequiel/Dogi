using Application.DTOs.WelcomeManager;
using Application.Interfaces.Repositories;
using Application.Managers;
using Application.Service.Abstraction;
using Application.Service.Abstraction.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Enums;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Managers
{
    public class WelcomeManagerTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddReceptionDocumentWithAnimalChipOwnerInformationIfDontHasChipAsync(
            ReceptionDocumentWithAnimalInformation receptionDocumentWithAnimalChipOwnerInformation,
            ReceptionDocument receptionDocumentGet,
            IndividualProceeding individualProceedingGet,
            AdminData adminData,
            [Frozen] Mock<IReceptionDocumentWrite> recepDocWriteMock,
            [Frozen] Mock<IIndividualProceedingWrite> individualProceedingWriteMock,
            [Frozen] Mock<IAnimalZoneRepository> animalZoneRepositoryMock,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            WelcomeManager sut) {
         {

            // Arrange
            individualProceedingGet.ReceptionDocumentId = receptionDocumentGet.Id;
            individualProceedingGet.ZoneId = (int)AnimalZone.Quarantine;
            receptionDocumentWithAnimalChipOwnerInformation.ReceptionDocument.HasChip = false;

            unitOfWorkMock.Setup(u => u.AnimalZoneRepository)
                .Returns(animalZoneRepositoryMock.Object);

            recepDocWriteMock.Setup(r => r.AddAsync(
                It.IsAny<ReceptionDocument>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentGet);
            
            individualProceedingWriteMock.Setup(i => i.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingGet);

            // Act
            var result = await sut.AddAnimalWithOwnerInfo(receptionDocumentWithAnimalChipOwnerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);

            Assert.Equal(receptionDocumentGet.Id, result.IndividualProceeding!.ReceptionDocumentId);
            Assert.Equal(individualProceedingGet.Id, result.IndividualProceeding!.Id);
            Assert.Equal(((int)AnimalZone.Quarantine), result.IndividualProceeding!.ZoneId);

            recepDocWriteMock.Verify(r => r.AddAsync(
                It.IsAny<ReceptionDocument>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            
            individualProceedingWriteMock.Verify(i => i.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}}
