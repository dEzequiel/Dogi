using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Moq;
using Test.Utils.Attributes;
using InvalidDataException = Crosscuting.Base.Exceptions.InvalidDataException;


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
    }
    
    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetAllReceptionDocumentsPaginatedAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        IEnumerable<ReceptionDocument> collectionDocument,
        ReceptionDocumentRead sut)
    {
        // Arrange
        int totalCount = 3;
        
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAllCountAsync())
            .ReturnsAsync(totalCount);
        
        repositoryMock.Setup(r => r.GetAllPaginatedAsync(It.IsAny<PaginatedRequest>()))
            .ReturnsAsync(collectionDocument);
        
        // Act
        var result = await sut.GetAllPaginatedAsync(new PaginatedRequest());
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.IsType<PageResponse<IEnumerable<Domain.Entities.ReceptionDocument>>>(result);
        Assert.Equal(totalCount, result.TotalCount);
    }
    
    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetAllReceptionDocumentsPaginatedFilterByChipPossessionAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        IEnumerable<ReceptionDocument> collectionDocument,
        ReceptionDocumentRead sut)
    {
        // Arrange
        int totalCount = 3;
        
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAllCountAsync())
            .ReturnsAsync(totalCount);
        
        repositoryMock.Setup(r => r.GetAllPaginatedFilterByChipPossessionAsync(
                It.IsAny<PaginatedRequest>(),
                It.IsAny<bool>()))
            .ReturnsAsync(collectionDocument);
        
        // Act
        var result = await sut.GetAllPaginatedFilterByChipPossession(new PaginatedRequest(), true);
        
        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.IsType<PageResponse<IEnumerable<Domain.Entities.ReceptionDocument>>>(result);
        Assert.Equal(totalCount, result.TotalCount);
    }
}