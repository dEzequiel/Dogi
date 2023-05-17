using Application.Features.IndividualPro.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;

namespace Test.Application.Features.IndividualProceeding.Command
{
    public class InsertIndividualProceedingRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIndividualProceedingDataProperty(Domain.Entities.IndividualProceeding data,
            AdminData adminData)
        {
            // Act
            var request = new InsertIndividualProceedingRequest(data, adminData);
            // Assert
            Assert.Equal(expected: data, actual: request.IndividualProceedingData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IIndividualProceedingWrite> individualProceedingWriteServiceMock,
            Domain.Entities.IndividualProceeding individualProceedingForGet,
            InsertIndividualProceedingRequest request,
            InsertIndividualProceedingRequestHandler handler)
        {
            // Arrange
            individualProceedingWriteServiceMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.IndividualProceeding>(),
                                                                                It.IsAny<AdminData>(),
                                                                                It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.IndividualProceeding>>(result);
            individualProceedingWriteServiceMock.Verify(i => i.AddAsync(It.IsAny<Domain.Entities.IndividualProceeding>(),
                                                                                It.IsAny<AdminData>(),
                                                                                It.IsAny<CancellationToken>()), Times.Once);
        } 
    }
}
