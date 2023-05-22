using Application.Features.IndividualProceedingStatus.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;

namespace Test.Application.Features.IndividualProceedingStatus.Queries
{
    public class GetIndividualProceedingStatusByIdRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdDataProperty(int id)
        {
            // Act
            var request = new GetIndividualProceedingStatusByIdRequest(id);
            // Assert
            Assert.Equal(expected: id, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]

        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IIndividualProceedingStatusReadService> individualProceedingStatusReadMock,
            Domain.Support.IndividualProceedingStatus statusForGet,
            GetIndividualProceedingStatusByIdRequest request,
            GetIndividualProceedingStatusByIdRequestHandler handler)
        {
            // Arrange
            individualProceedingStatusReadMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(statusForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Support.IndividualProceedingStatus>>(result);
            individualProceedingStatusReadMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
