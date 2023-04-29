using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using AutoMapper;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServicesTest
{
    public class ReceptionDocumentWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewReceptionDocumentAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            Domain.Entities.ReceptionDocument documentAdd,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(It.IsAny<Domain.Entities.ReceptionDocument>()))
                .Returns(Task.CompletedTask);

            // act
            var result = await sut.AddAsync(documentAdd, admin);

            // Assert
            Assert.Equal(result.Observations, documentAdd.Observations);

        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldMarkAsSoftDeletedReceptionDOcumentAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IReceptionDocumentRepository> repositoryMock,
            [Frozen] AdminData admin,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            var idToDelete = Guid.NewGuid();

            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.LogicRemoveAsync(It.IsAny<Guid>(), It.IsAny<AdminData>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.LogicRemoveAsync(idToDelete, admin);

            // Assert
            Assert.True(result);
        }

        //[Theory]
        //[AutoMoqData]
        //internal async Task ShouldThrowInvalidDataExceptionWhenAddReceptionDocumentAsync(
        //    [Frozen] Mock<Domain.Entities.ReceptionDocument> receptionDocumentEntityMock,
        //    [Frozen] Mock<IMapper> mapperMock,
        //    Domain.Entities.ReceptionDocument documentAdd,
        //    ReceptionDocumentWrite sut)
        //{

        //    // Arrange
        //    var invalidDocument = new Domain.Entities.ReceptionDocument(Guid.Empty, documentAdd.HasChip, 
        //                                                                documentAdd.Observations, 
        //                                                                documentAdd.PickupLocation, 
        //                                                                documentAdd.PickupDate);

        //    mapperMock.Setup(m => m.Map<Domain.Entities.ReceptionDocument>(It.IsAny<Domain.Entities.ReceptionDocument>()))
        //             .Returns(invalidDocument);
        //    receptionDocumentEntityMock.Setup(x => x.Verify(invalidDocument))
        //        .Returns(Result.Failure<Domain.Entities.ReceptionDocument>(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty));

        //    // Act & Assert
        //    var ex = await Assert.ThrowsAsync<InvalidDataException>(() => sut.AddAsync(documentAdd));
        //    Assert.Equal(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty.Message, ex.Message);
        //}
    }
    
}
