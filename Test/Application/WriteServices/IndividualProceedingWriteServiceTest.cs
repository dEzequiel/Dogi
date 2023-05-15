using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class IndividualProceedingWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewIndividualProceedingAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingRepository> repositoryMock,
            [Frozen] AdminData admin,
            IndividualProceeding individualProceedingAdd,
            IndividualProceedingWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.IndividualProceedingRepository)
                .Returns(repositoryMock.Object);
            
            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            
            // act
            var result = await sut.AddAsync(individualProceedingAdd, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<IndividualProceeding>(result);

            unitOfWorkMock.Verify(u => u.IndividualProceedingRepository, Times.Once);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntAddNewIndividualProceedingIfIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingRepository> repositoryMock,
            [Frozen] AdminData admin,
            IndividualProceedingWrite sut)
        {
            // Arrange
            IndividualProceeding individualProceedingAdd = null!;

            unitOfWorkMock.Setup(u => u.IndividualProceedingRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(individualProceedingAdd, admin));
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldnAddNewIndividualProceedingIfAdminIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingRepository> repositoryMock,
            [Frozen] IndividualProceeding individualProceedingAdd,
            IndividualProceedingWrite sut)
        {
            // Arrange
            AdminData admin = null!;

            unitOfWorkMock.Setup(u => u.IndividualProceedingRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<IndividualProceeding>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(individualProceedingAdd, admin));
        }
    }
}

