using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using AutoFixture.Xunit2;
using Domain.Entities.Shelter;
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