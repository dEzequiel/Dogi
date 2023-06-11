using Application.DTOs.VeterinaryManager;
using Application.Features.Cage.Commands;
using Application.Features.IndividualPro.Queries;
using Application.Features.MedicalRecord.Comamnds;
using Application.Features.MedicalRecord.Commands;
using Application.Features.MedicalRecordStatus.Queries;
using Application.Features.VaccinationCardVaccine.Commands;
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

namespace Test.Application.Managers;

public class VeterinaryManagerTest
{
    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldCreateMedicalRecordWithoutAssignedVaccinesAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            MedicalRecord medicalRecordInput,
            AdminData adminData,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            ApiResponse<MedicalRecordStatus> medicalRecordStatusApiResponse,
            ApiResponse<MedicalRecord> medicalResponseApiResponse,
            ApiResponse<Cage> cageApiResponse,
            IEnumerable<Guid> vaccines,
            VeterinaryManager sut)

    {
        // Arrange
        medicalRecordInput.IndividualProceedingId = individualProceedingApiResponse.Data.Id;
        medicalRecordInput.MedicalStatusId = medicalRecordStatusApiResponse.Data.Id;

        mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingByIdRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(individualProceedingApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<MoveCageAnimalZoneRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(cageApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalRecordStatusApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalResponseApiResponse);

        // Act
        var result = await sut.CreateMedicalRecord(individualProceedingApiResponse.Data.Id,
            medicalRecordInput, null, adminData, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<IndividualProceedingWithMedicalRecord>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetIndividualProceedingByIdRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<MoveCageAnimalZoneRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldCreateMedicalRecordWithAssignedVaccinesAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            MedicalRecord medicalRecordInput,
            AdminData adminData,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            ApiResponse<MedicalRecordStatus> medicalRecordStatusApiResponse,
            ApiResponse<MedicalRecord> medicalResponseApiResponse,
            ApiResponse<Cage> cageApiResponse,
            ApiResponse<IEnumerable<VaccinationCardVaccine>> vaccinationCardVaccineApiResponse,
            IEnumerable<Guid> vaccines,
            VeterinaryManager sut)

    {
        // Arrange
        medicalRecordInput.IndividualProceedingId = individualProceedingApiResponse.Data.Id;
        medicalRecordInput.MedicalStatusId = medicalRecordStatusApiResponse.Data.Id;

        mediatorMock.Setup(x => x.Send(It.IsAny<GetIndividualProceedingByIdRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(individualProceedingApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<MoveCageAnimalZoneRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(cageApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalRecordStatusApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalResponseApiResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<InsertCollectionVaccinationCardVaccineVaccinesRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(vaccinationCardVaccineApiResponse);

        // Act
        var result = await sut.CreateMedicalRecord(individualProceedingApiResponse.Data.Id,
            medicalRecordInput, vaccines, adminData, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<IndividualProceedingWithMedicalRecord>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetIndividualProceedingByIdRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<MoveCageAnimalZoneRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetMedicalRecordStatusByIdRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<InsertMedicalRecordRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<InsertCollectionVaccinationCardVaccineVaccinesRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldCheckMedicalRecordAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            AdminData adminData,
            string observations,
            ApiResponse<MedicalRecord> medicalRecordApiResponse,
            VeterinaryManager sut)
    {
        // Arange
        var medicalRecordIdToCheck = Guid.NewGuid();

        mediatorMock.Setup(x => x.Send(It.IsAny<CheckMedicalRecordRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalRecordApiResponse);

        // Act
        var result = await sut.CheckMedicalRecord(medicalRecordIdToCheck, observations,
            adminData, default);

        // Assert
        // Assert
        Assert.NotNull(result);
        Assert.IsType<IndividualProceedingWithMedicalRecord>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<CheckMedicalRecordRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldCloseMedicalRecordAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            AdminData adminData,
            string observations,
            ApiResponse<MedicalRecord> medicalRecordApiResponse,
            VeterinaryManager sut)
    {
        // Arange
        var medicalRecordIdToCheck = Guid.NewGuid();

        mediatorMock.Setup(x => x.Send(It.IsAny<CloseMedicalRecordRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(medicalRecordApiResponse);

        // Act
        var result = await sut.CloseMedicalRecord(medicalRecordIdToCheck, observations,
            adminData, default);

        // Assert
        // Assert
        Assert.NotNull(result);
        Assert.IsType<IndividualProceedingWithMedicalRecord>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<CloseMedicalRecordRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldVaccineAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            AdminData adminData,
            VaccinesToComplish vaccines,
            ApiResponse<IEnumerable<VaccinationCardVaccine>> vaccinationCardVaccineApiResponse,
            VeterinaryManager sut)
    {
        // Arange
        var vaccinationCardId = Guid.NewGuid();

        mediatorMock.Setup(x => x.Send(It.IsAny<VaccinationCardVaccineVaccineRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(vaccinationCardVaccineApiResponse);

        // Act
        var result = await sut.Vaccine(vaccinationCardId, vaccines,
            adminData, default);

        // Assert
        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<VaccinationCardVaccine>>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<VaccinationCardVaccineVaccineRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}