﻿using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using AutoFixture.Xunit2;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class CageWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldSetCageOccupiedToFalse(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<ICageRepository> repositoryMock,
            CageWrite sut)
        {
            // Arrange
            var cageIdToSetOccupiedToFalse = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.CageRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.UpdateOccupiedStatusAsync(
                    It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.UpdateOccupiedStatusAsync(cageIdToSetOccupiedToFalse, default);

            // Assert
            Assert.True(result);

            unitOfWorkMock.Verify(u => u.CageRepository, Times.Once);
            repositoryMock.Verify(r => r.UpdateOccupiedStatusAsync(
                It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}