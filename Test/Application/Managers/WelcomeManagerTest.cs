using Application.DTOs.WelcomeManager;
using Application.Features.AnimalCategory.Queries;
using Application.Features.Cage.Commands;
using Application.Features.Cage.Queries;
using Application.Features.IndividualPro.Commands;
using Application.Features.IndividualProceedingStatus.Queries;
using Application.Features.InsertAnimalChipRequest.Commands;
using Application.Features.MedicalRecord.Comamnds;
using Application.Features.ReceptionDocument.Commands;
using Application.Features.Sex.Queries;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Domain.Support;
using MediatR;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Managers
{
    public class WelcomeManagerTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldRegisterInformationAboutReceptionDocumentAndIndividualProceedingIfAnimalHasNoChipAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            ApiResponse<Cage> cageApiResponse,
            ApiResponse<bool> isOccupiedCageApiResponse,
            ApiResponse<IndividualProceedingStatus> individualProceedingStatusApiResponse,
            ApiResponse<AnimalCategory> animalCategoryApiResponse,
            ApiResponse<Sex> sexApiResponse,
            ApiResponse<MedicalRecord> medicalRecordResponse,
            RegisterInformation registerInformation,
            AdminData adminData,
            WelcomeManager sut)
        {
            // Arrange
            registerInformation.ReceptionDocument.HasChip = false;

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(cageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(isOccupiedCageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingStatusApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetAnimalCategoryByIdRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalCategoryApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(sexApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                   It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
                   It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordResponse);

            // Act
            var result = await sut.RegisterAnimal(registerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                    It.IsAny<CancellationToken>()), Times.Once);


            mediatorMock.Verify(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
                    It.IsAny<CancellationToken>()), Times.Once);

        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldRegisterInformationAboutReceptionDocumentIndividualProceedingAndAnimalChipIfAnimalHasChipAndOwnerIsResponsibleAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            ApiResponse<Cage> cageApiResponse,
            ApiResponse<bool> isOccupiedCageApiResponse,
            ApiResponse<AnimalChip> animalChipApiResponse,
            ApiResponse<AnimalCategory> animalCategoryApiResponse,
            ApiResponse<Sex> sexApiResponse,
            ApiResponse<IndividualProceedingStatus> individualProceedingStatusApiResponse,
            RegisterInformation registerInformation,
            AdminData adminData,
            WelcomeManager sut)
        {
            // Arrange
            registerInformation.ReceptionDocument!.HasChip = true;
            registerInformation.AnimalChip!.OwnerIsResponsible = true;

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(cageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(isOccupiedCageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalChipApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetAnimalCategoryByIdRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalCategoryApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(sexApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingStatusApiResponse);


            // Act
            var result = await sut.RegisterAnimal(registerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
