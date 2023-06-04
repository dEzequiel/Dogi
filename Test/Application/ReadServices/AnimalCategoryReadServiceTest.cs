using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using AutoFixture.Xunit2;
using Domain.Entities.Shelter;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.ReadServices
{
    public class AnimalCategoryReadServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldGetAnimalCategoryByIdAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IAnimalCategoryRepository> repositoryMock,
            AnimalCategory category,
            AnimalCategoryRead sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.AnimalCategoryRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(category);

            // Act
            var result = await sut.GetByIdAsync(category.Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AnimalCategory>(result);

            unitOfWorkMock.Verify(u => u.AnimalCategoryRepository, Times.Once);
            repositoryMock.Verify(r => r.GetAsync(It.IsAny<int>()), Times.Once);
        }
    }
}