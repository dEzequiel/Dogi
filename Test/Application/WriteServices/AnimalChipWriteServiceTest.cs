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
    public class AnimalChipWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewAnimalChipAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IAnimalChipRepository> repositoryMock,
            [Frozen] AdminData admin,
            AnimalChip animalChipAdd,
            AnimalChipWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.AnimalChipRepository)
                .Returns(repositoryMock.Object);
            
            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<AnimalChip>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            
            // act
            var result = await sut.AddAsync(animalChipAdd, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AnimalChip>(result);

            unitOfWorkMock.Verify(u => u.AnimalChipRepository, Times.Once);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<AnimalChip>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntAddNewAnimalChipIfIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IAnimalChipRepository> repositoryMock,
            [Frozen] AdminData admin,
            AnimalChipWrite sut)
        {
            // Arrange
            AnimalChip animalChipAdd = null!;

            unitOfWorkMock.Setup(u => u.AnimalChipRepository)
                .Returns(repositoryMock.Object);
            
            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<AnimalChip>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            
            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(animalChipAdd, admin));
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntAddNewAnimalChipIfAdminIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IAnimalChipRepository> repositoryMock,
            [Frozen] AnimalChip animalChipAdd,
            AnimalChipWrite sut)
        {
            // Arrange
            AdminData admin = null!;

            unitOfWorkMock.Setup(u => u.AnimalChipRepository)
                .Returns(repositoryMock.Object);
            
            repositoryMock.Setup(r => r.AddAsync(
                It.IsAny<AnimalChip>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);
            
            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(animalChipAdd, admin));
        }
    }
}