using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class IndividualProceedingWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewIndividualProceedingAsync(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIndividualProceedingRepository> repositoryMock,
            [Frozen] AdminData admin,
            IndividualProceeding individualProceedingAdd,
            IndividualProceedingWrite sut)
        {
            // Arrange
            CancellationToken cancellationToken = new CancellationToken();
            individualProceedingAdd.AnimalId = individualProceedingAdd.Animal.Id;
            individualProceedingAdd.ReceptionDocumentId = individualProceedingAdd.ReceptionDocument.Id;
            //individualProceedingAdd.StatusId = individualProceedingAdd.Status.Id;

            unitOfWorkMock.Setup(u => u.IndividualProceedingRepository).Returns(repositoryMock.Object);

            repositoryMock.Setup(r => r.AddAsync(It.IsAny<IndividualProceeding>(), It.IsAny<AdminData>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.AddAsync(individualProceedingAdd, admin, cancellationToken);

            // Assert
            Assert.Equal(result.StatusId, individualProceedingAdd.StatusId);
            Assert.Equal(result.AnimalId, individualProceedingAdd.AnimalId);
            Assert.Equal(result.ReceptionDocumentId, individualProceedingAdd.ReceptionDocumentId);
        }
    }
}
