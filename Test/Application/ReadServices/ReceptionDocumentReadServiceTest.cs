using Application.DTOs.ReceptionDocument;
using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
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
        ReceptionDocumentForGet documentGet,
        ReceptionDocument document,
        ReceptionDocumentRead sut)
    {
        // Arrange
        documentGet.Id = document.Id;
        
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(document);
        
        // Act
        var result = await sut.GetByIdAsync(document.Id);
        
        // Assert
        Assert.Equal(document.Id, documentGet.Id);
    }

    [Theory]
    [AutoMoqData]
    internal async Task ShouldThrowInvalidDataExceptionIfReturnedDocumentNotValidAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        [Frozen] Mock<Domain.Entities.ReceptionDocument> receptionDocumentEntityMock,
        ReceptionDocument document,
        ReceptionDocumentForAdd documentAdd,
        ReceptionDocumentRead sut)
    {
        // Arrange
        var invalidDocument = new Domain.Entities.ReceptionDocument(Guid.Empty, documentAdd.HasChip, 
            documentAdd.Observations, 
            documentAdd.PickupLocation, 
            documentAdd.PickupDate);
        
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(invalidDocument);
        
        receptionDocumentEntityMock.Setup(x => x.Verify(invalidDocument))
            .Returns(Result.Failure<Domain.Entities.ReceptionDocument>(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty));
        
        // Act & Assert
        var ex = await Assert.ThrowsAsync<InvalidDataException>(() => sut.GetByIdAsync(document.Id));
        Assert.Equal(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty.Message, ex.Message);
    }
    
    [Theory]
    [AutoMoqData]
    internal async Task ShouldGetAllReceptionDocumentsAsync(
        [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
        [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
        IEnumerable<ReceptionDocument> collectionDocumentGet,
        ReceptionDocumentRead sut)
    {
        // Arrange
        unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

        repositoryMock.Setup(r => r.GetAllAsync())
            .ReturnsAsync(collectionDocumentGet);
        
        // Act
        var result = await sut.GetAllAsync();
        
        // Assert
        //Assert.Equal(document.Id, documentGet.Id);
    }
}