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
            Domain.Entities.MedicalRecord medicalRecordAdd,
            MedicalRecordWrite sut)
        {
            // Arrange
            var medicalRecordToCheck = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.MedicalRecordRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.CompleteRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordAdd);

            // Act
            var result = await sut.CheckAsync(medicalRecordToCheck, adminDataMock);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.MedicalRecord>(result);

            unitOfWorkMock.Verify(u => u.MedicalRecordRepository, Times.Once);
            repositoryMock.Verify(r => r.CompleteRevisionAsync(
                It.IsAny<Guid>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
