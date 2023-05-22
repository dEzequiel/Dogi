using Application.Features.ReceptionDocument.Commands;
using Application.Service.Abstraction;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.ReceptionDocument.Commands
{
    public class LogicRemoveReceptionDocumentRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdProperty(Guid idToDelete, [Frozen] AdminData admin)
        {
            // Act
            var request = new LogicRemoveReceptionDocumentRequest(idToDelete, admin);
            // Assert
            Assert.Equal(expected: idToDelete, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IReceptionDocumentWriteService> receptionDocumentWriteServiceMock,
            LogicRemoveReceptionDocumentRequest request,
            LogicRemoveReceptionDocumentRequestHandler handler)
        {
            // Arrange
            receptionDocumentWriteServiceMock.Setup(x => x.LogicRemoveAsync(It.IsAny<Guid>(), It.IsAny<AdminData>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<bool>>(result);
        }
    }
}
