using Application.DTOs.ReceptionDocument;
using Application.Service.Implementation.Command;
using Application.Service.Implementation.Read;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Domain.Entities;
using Domain.Interfaces.Repositories;
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
}