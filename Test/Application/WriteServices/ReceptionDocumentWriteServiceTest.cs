using Application.Interfaces;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Domain.Entities.Shelter;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class ReceptionDocumentWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewReceptionDocumentAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            ReceptionDocument documentAdd,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                    It.IsAny<ReceptionDocument>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // act
            var result = await sut.AddAsync(documentAdd, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ReceptionDocument>(result);

            unitOfWorkMock.Verify(u => u.ReceptionDocumentRepository, Times.Once);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<ReceptionDocument>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntAddNewReceptionDocumentIfIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            ReceptionDocument documentAdd = null!;

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                    It.IsAny<ReceptionDocument>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(documentAdd, admin));
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntAddNewReceptionDocumentIfAdminIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            ReceptionDocument documentAdd,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            AdminData admin = null!;

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(
                    It.IsAny<ReceptionDocument>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // act & assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.AddAsync(documentAdd, admin));
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldMarkAsSoftDeletedReceptionDocumentAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            var idToDelete = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.LogicRemoveAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.LogicRemoveAsync(
                idToDelete,
                admin);

            // Assert
            Assert.True(result);
            unitOfWorkMock.Verify(u => u.ReceptionDocumentRepository, Times.Once);
            repositoryMock.Verify(r => r.LogicRemoveAsync(
                It.IsAny<Guid>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntMarkAsSoftDeletedReceptionDocumentIfIdIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            var idToDelete = Guid.Empty;

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.LogicRemoveAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => sut.LogicRemoveAsync(
                idToDelete,
                admin));
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldntMarkAsSoftDeletedIfAdminIsNullAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            var idToDelete = Guid.NewGuid();
            AdminData admin = null!;

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.LogicRemoveAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => sut.LogicRemoveAsync(
                idToDelete,
                admin));
        }
    }
}