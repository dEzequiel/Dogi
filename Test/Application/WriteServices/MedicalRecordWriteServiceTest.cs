using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class MedicalRecordWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewMedicalRecordAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IMedicalRecordRepository> repositoryMock,
            [Frozen] AdminData adminDataMock,
            Domain.Entities.MedicalRecord medicalRecordAdd,
            MedicalRecordWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.MedicalRecordRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<Domain.Entities.MedicalRecord>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.AddAsync(medicalRecordAdd, adminDataMock);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.MedicalRecord>(result);

            unitOfWorkMock.Verify(u => u.MedicalRecordRepository, Times.Once);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<Domain.Entities.MedicalRecord>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldSetAsCheckedMedicalRecordStatusAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IMedicalRecordRepository> repositoryMock,
            [Frozen] AdminData adminDataMock,
            Guid medicalRecordAdd,
            string observations,
            Domain.Entities.MedicalRecord medicalRecordReturn,
            AdminData admin,
            MedicalRecordWrite sut)
        {
            // Arrange
            Guid id = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.MedicalRecordRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.CompleteRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordReturn);

            // Act
            var result = await sut.CheckAsync(id, observations, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.MedicalRecord>(result);

            unitOfWorkMock.Verify(u => u.MedicalRecordRepository, Times.Once);
            repositoryMock.Verify(r => r.CompleteRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldSetAsCloseMedicalRecordStatusAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IMedicalRecordRepository> repositoryMock,
            [Frozen] AdminData adminDataMock,
            Domain.Entities.MedicalRecord medicalRecordAdd,
            string conclusions,
            MedicalRecordWrite sut)
        {
            // Arrange
            var medicalRecordToClose = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.MedicalRecordRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.CloseRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordAdd);

            // Act
            var result = await sut.CloseAsync(medicalRecordToClose, conclusions, adminDataMock);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.MedicalRecord>(result);

            unitOfWorkMock.Verify(u => u.MedicalRecordRepository, Times.Once);
            repositoryMock.Verify(r => r.CloseRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldUpdateMedicalRecordStringFieldsAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IMedicalRecordRepository> repositoryMock,
            [Frozen] AdminData adminDataMock,
            Domain.Entities.MedicalRecord medicalRecordUpdate,
            MedicalRecordWrite sut)
        {
            // Arrange
            var medicalRecordToUpdate = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.MedicalRecordRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.UpdateAsync(
                It.IsAny<Guid>(),
                It.IsAny<Domain.Entities.MedicalRecord>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordUpdate);

            // Act
            var result = await sut.UpdateAsync(medicalRecordToUpdate, medicalRecordUpdate, adminDataMock);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.MedicalRecord>(result);

            unitOfWorkMock.Verify(u => u.MedicalRecordRepository, Times.Once);
            repositoryMock.Verify(r => r.UpdateAsync(
                It.IsAny<Guid>(),
                It.IsAny<Domain.Entities.MedicalRecord>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
