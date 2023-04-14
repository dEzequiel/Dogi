using Application.DTOs.ReceptionDocument;
using Application.Service.Implementation.Command;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            repositoryMock.Setup(r => r.AddAsync(It.IsAny<ReceptionDocument>()))
                .Returns(Task.CompletedTask);

            // act
            var result = await sut.AddAsync(documentAdd);

            // Assert
            Assert.Equal(result.Observations, documentAdd.Observations);

        } 
    }
}
