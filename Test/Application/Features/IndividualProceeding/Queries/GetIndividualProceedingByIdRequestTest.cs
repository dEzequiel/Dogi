using Application.Features.IndividualPro.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.IndividualProceeding.Queries
{
    public class GetIndividualProceedingByIdRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdDataProperty(Guid id)
        {
            // Act
            var request = new GetIndividualProceedingByIdRequest(id);
            // Assert
            Assert.Equal(expected: id, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
        [Frozen] Mock<IIndividualProceedingReadService> individualProceedingReadService,
        Domain.Entities.IndividualProceeding individualProceedingForGet,
        GetIndividualProceedingByIdRequest request,
        GetIndividualProceedingByIdRequestHandler handler)
        {
            // Arrange
            individualProceedingReadService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.IndividualProceeding>>(result);
            individualProceedingReadService.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
        }
    }
}
