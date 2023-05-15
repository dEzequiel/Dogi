using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Domain.Entities;
using Moq;
using Test.Utils.Attributes;


namespace Test.Application.ReadServices;

public class ReceptionDocumentReadServiceTest
{
    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetReceptionDocumentByIdAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        Domain.Entities.ReceptionDocument documentGet,
        ReceptionDocument document,
        ReceptionDocumentRead sut)
    {
        // Arrange
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(document);
        
        // Act
        var result = await sut.GetByIdAsync(document.Id);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ReceptionDocument>(result);

        unitOfWorkMock.Verify(u => u.ReceptionDocumentRepository, Times.Once);
        repositoryMock.Verify(r => r.GetAsync(It.IsAny<Guid>()), Times.Once);
    }
    
    [Theory]
    [AutoMoqData]
    internal async Task ShouldThrowArgumentNullExceptionIfIdIsNullAsync(
        ReceptionDocumentRead sut,
        Guid idToSearch)
    {
        // Assert
        Guid id = Guid.Empty;
    
        // Act & assert
        await Assert.ThrowsAsync<ArgumentException>(() => sut.GetByIdAsync(id));
    }

    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetAllReceptionDocumentsAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        IEnumerable<ReceptionDocument> collectionDocument,
        ReceptionDocumentRead sut)
    {
        // Arrange
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(collectionDocument);

        // Act
        CancellationToken ct = default;
        var result = await sut.GetAllAsync(ct);
        
        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ReceptionDocument>>(result);
    }
    
    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetAllReceptionDocumentsFilterByChipPossessionAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        IEnumerable<ReceptionDocument> collectionDocument,
        ReceptionDocumentRead sut)
    {
        // Arrange
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        
        repositoryMock.Setup(r => r.GetAllFilterByChipPossessionAsync(
                It.IsAny<bool>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(collectionDocument);
        
        // Act
        var result = await sut.GetAllFilterByChipAsync(false);
        
        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ReceptionDocument>>(result);
    }
}