using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using AutoFixture.Xunit2;
using Domain.Entities.Shelter;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.ReadServices
{
    public class IndividualProceedingStatusReadServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldGetIndividualProceedingStatusByIdAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingStatusRepository> repositoryMock,
            IndividualProceedingStatus status,
            IndividualProceedingStatusRead sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.IndividualProceedingStatusRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(status);

            // Act
            var result = await sut.GetByIdAsync(status.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<IndividualProceedingStatus>(result);

            unitOfWorkMock.Verify(u => u.IndividualProceedingStatusRepository, Times.Once);
            repositoryMock.Verify(r => r.GetAsync(It.IsAny<int>()), Times.Once);
        }
    }
}