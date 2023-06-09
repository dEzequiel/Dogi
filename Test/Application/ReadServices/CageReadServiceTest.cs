﻿using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Read;
using AutoFixture.Xunit2;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.ReadServices
{
    public class CageReadServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldGetFreeCageByZone(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<ICageRepository> cageRepositoryMock,
            Cage freeCage,
            CageRead sut)
        {
            // Arrange
            freeCage.IsOccupied = false;
            freeCage.AnimalZoneId = ((int)AnimalZones.Dogs);

            unitOfWorkMock.Setup(u => u.CageRepository).Returns(cageRepositoryMock.Object);

            cageRepositoryMock.Setup(r => r.GetFreeCageByZoneAsync(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(freeCage);

            // Act
            var result = await sut.GetFreeCageByZone(((int)AnimalZones.Dogs));

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Cage>(result);
            Assert.Equal(expected: freeCage.IsOccupied, actual: result.IsOccupied);
            Assert.Equal(expected: freeCage.AnimalZoneId, actual: result.AnimalZoneId);

            unitOfWorkMock.Verify(u => u.CageRepository, Times.Once);
            cageRepositoryMock.Verify(r => r.GetFreeCageByZoneAsync(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}