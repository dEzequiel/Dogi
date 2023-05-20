using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Domain.Support;
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
