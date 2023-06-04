using Application.Features.Cage.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.Cage.Queries
{
    public class GetFreeCageByZoneRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetCageDataProperty(int zoneId)
        {
            // Act
            var request = new GetFreeCageByZoneRequest(zoneId);
            // Assert
            Assert.Equal(expected: zoneId, actual: request.ZoneId);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShoudlCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<ICageReadService> cageReadServiceMock,
            Domain.Entities.Shelter.Cage cageForGet,
            GetFreeCageByZoneRequest request,
            GetFreeCageByZoneRequestHandler handler)
        {
            // Arrange
            cageReadServiceMock.Setup(x => x.GetFreeCageByZone(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(cageForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.Shelter.Cage>>(result);
            cageReadServiceMock.Verify(i => i.GetFreeCageByZone(It.IsAny<int>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}