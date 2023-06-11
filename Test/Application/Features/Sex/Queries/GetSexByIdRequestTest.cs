using Application.Features.Sex.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.Sex.Queries
{
    public class GetSexByIdRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdDataProperty(int id)
        {
            // Act
            var request = new GetSexByIdRequest(id);
            // Assert
            Assert.Equal(expected: id, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<ISexReadService> sexReadMock,
            Domain.Entities.Shelter.Sex sexForGet,
            GetSexByIdRequest request,
            GetSexByIdRequestHandler handler)
        {
            // Arrange
            sexReadMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(sexForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.Shelter.Sex>>(result);
            sexReadMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}