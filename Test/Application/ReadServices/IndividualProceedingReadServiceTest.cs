using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using AutoFixture.Xunit2;
using Domain.Entities.Shelter;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.ReadServices
{
    public class IndividualProceedingReadServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldGetIndividualProceedingByIdAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingRepository> repositoryMock,
            IndividualProceeding individualProceeding,
            IndividualProceedingReadService sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.IndividualProceedingRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(individualProceeding);

            // Act
            var result = await sut.GetByIdAsync(individualProceeding.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<IndividualProceeding>(result);

            unitOfWorkMock.Verify(u => u.IndividualProceedingRepository, Times.Once);
            repositoryMock.Verify(r => r.GetAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}