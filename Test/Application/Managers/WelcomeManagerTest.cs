using Application.DTOs.WelcomeManager;
using Application.Features.AnimalCategory.Queries;
using Application.Features.AnimalChip.Commands;
using Application.Features.Cage.Commands;
using Application.Features.Cage.Queries;
using Application.Features.IndividualPro.Commands;
using Application.Features.IndividualProceedingStatus.Queries;
using Application.Features.MedicalRecord.Comamnds;
using Application.Features.MedicalRecordStatus.Queries;
using Application.Features.Person.Commands;
using Application.Features.PersonBannedInformation.Commands;
using Application.Features.ReceptionDocument.Commands;
using Application.Features.Sex.Queries;
using Application.Features.VaccinationCard.Commands;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Domain.Entities.Shelter;
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
        internal async Task
            ShouldCreateAllEntryMechanismWhenAnimalHasNoChipAsync(
                [Frozen] Mock<IMediator> mediatorMock,
                ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
                ApiResponse<IndividualProceeding> individualProceedingApiResponse,
                ApiResponse<Cage> cageApiResponse,
                ApiResponse<bool> isOccupiedCageApiResponse,
                ApiResponse<IndividualProceedingStatus> individualProceedingStatusApiResponse,
                ApiResponse<AnimalCategory> animalCategoryApiResponse,
                ApiResponse<Sex> sexApiResponse,
                ApiResponse<MedicalRecord> medicalRecordResponse,
                ApiResponse<VaccinationCard> vaccinationCardResponse,
                ApiResponse<MedicalRecordStatus> medicalRecordStatusResponse,
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

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertVaccinationCardRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccinationCardResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordStatusResponse);


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

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertVaccinationCardRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetAnimalCategoryByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task
            ShouldCreateAllWaitingForOwnerMechanismWhenAnimalHasChipAndOwnerIsResponsibleAsync(
                [Frozen] Mock<IMediator> mediatorMock,
                ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
                ApiResponse<Person> personApiResponse,
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

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertPersonRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(personApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingStatusApiResponse);

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

            // Act
            var result = await sut.RegisterAnimal(registerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertPersonRequest>(),
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

            mediatorMock.Verify(x => x.Send(It.IsAny<GetAnimalCategoryByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task
            ShouldCreateAllEntryMechanismWhenAnimalHasChipAndOwnerIsNotResponsibleAsync(
                [Frozen] Mock<IMediator> mediatorMock,
                ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
                ApiResponse<Person> personApiResponse,
                ApiResponse<IndividualProceeding> individualProceedingApiResponse,
                ApiResponse<Cage> cageApiResponse,
                ApiResponse<bool> isOccupiedCageApiResponse,
                ApiResponse<AnimalChip> animalChipApiResponse,
                ApiResponse<AnimalCategory> animalCategoryApiResponse,
                ApiResponse<Sex> sexApiResponse,
                ApiResponse<IndividualProceedingStatus> individualProceedingStatusApiResponse,
                ApiResponse<PersonBannedInformation> personBannedInformationApiResponse,
                ApiResponse<Person> banPersonApiResponse,
                ApiResponse<VaccinationCard> vaccinationCardResponse,
                ApiResponse<MedicalRecordStatus> medicalRecordStatusResponse,
                ApiResponse<MedicalRecord> medicalRecordResponse,
                RegisterInformation registerInformation,
                AdminData adminData,
                WelcomeManager sut)
        {
            // Arrange
            registerInformation.ReceptionDocument!.HasChip = true;
            registerInformation.AnimalChip!.OwnerIsResponsible = false;

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetAnimalCategoryByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalCategoryApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertPersonRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(personApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalChipApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingStatusApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(cageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(isOccupiedCageApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(sexApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertPersonBannedInformationRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(personBannedInformationApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<BanPersonRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(banPersonApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertVaccinationCardRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccinationCardResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordStatusResponse);

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

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertPersonRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetIndividualProceedingStatusByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetFreeCageByZoneRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCageOccupiedStatusRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetSexByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertPersonBannedInformationRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<BanPersonRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertVaccinationCardRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}