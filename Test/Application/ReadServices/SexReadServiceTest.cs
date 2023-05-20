using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Domain.Support;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.ReadServices
{
    public class SexReadServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldGetSexByIdAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<ISexRepository> repositoryMock,
            Sex sex,
            SexRead sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.SexRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(sex);

            // Act
            var result = await sut.GetByIdAsync(sex.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Sex>(result);

            unitOfWorkMock.Verify(u => u.SexRepository, Times.Once);
            repositoryMock.Verify(r => r.GetAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
