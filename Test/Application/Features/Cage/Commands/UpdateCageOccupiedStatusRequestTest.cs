using Application.Features.Cage.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.Cage.Commands
{
    public class UpdateCageOccupiedStatusRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetCageDataProperty(Guid data)
        {
            // Act
            var request = new UpdateCageOccupiedStatusRequest(data);
            // Assert
            Assert.Equal(expected: data, actual: request.CageId);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<ICageWrite> cageWriteServiceMock,
            UpdateCageOccupiedStatusRequest request,
            UpdateCageOccupiedStatusRequestHandler handler)
        {
            // Arrange
            cageWriteServiceMock.Setup(x => x.UpdateOccupiedStatusAsync(It.IsAny<Guid>(),
                                                                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<bool>>(result);
            cageWriteServiceMock.Verify(i => i.UpdateOccupiedStatusAsync(It.IsAny<Guid>(),
                                                                        It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
