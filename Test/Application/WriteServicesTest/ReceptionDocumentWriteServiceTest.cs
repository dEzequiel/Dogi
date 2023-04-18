using Application.DTOs.ReceptionDocument;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using AutoMapper;
using Domain.Exceptions;
using Domain.Exceptions.Result;
using Domain.Interfaces.Repositories;
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
            ReceptionDocumentForAdd documentAdd,
            ReceptionDocumentWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.ReceptionDocumentRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(It.IsAny<Domain.Entities.ReceptionDocument>()))
                .Returns(Task.CompletedTask);

            // act
            var result = await sut.AddAsync(documentAdd);

            // Assert
            Assert.Equal(result.Observations, documentAdd.Observations);

        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldThrowInvalidDataExceptionWhenAddReceptionDocumentAsync(
            [Frozen] Mock<Domain.Entities.ReceptionDocument> receptionDocumentEntityMock,
            [Frozen] Mock<IMapper> mapperMock,
            ReceptionDocumentForAdd documentAdd,
            ReceptionDocumentWrite sut)
        {

            // Arrange
            var invalidDocument = new Domain.Entities.ReceptionDocument(Guid.Empty, documentAdd.HasChip, documentAdd.Observations, documentAdd.PickupLocation, documentAdd.PickupDate);
            mapperMock.Setup(m => m.Map<Domain.Entities.ReceptionDocument>(It.IsAny<ReceptionDocumentForAdd>())).Returns(invalidDocument);
            receptionDocumentEntityMock.Setup(x => x.Verify(invalidDocument))
                .Returns(Result.Failure<Domain.Entities.ReceptionDocument>(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty));

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidDataException>(() => sut.AddAsync(documentAdd));
            Assert.Equal(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty.Message, ex.Message);
        }
    }
    
}
