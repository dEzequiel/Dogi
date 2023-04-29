using Application.Features.ReceptionDocument.Commands;
using Application.Service.Abstraction;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;

namespace Test.Application.Features.ReceptionDocument.Commands
{
    public class LogicRemoveReceptionDocumentRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdProperty(Guid idToDelete)
        {
            // Act
            var request = new LogicRemoveReceptionDocumentRequest(idToDelete);
            // Assert
            Assert.Equal(expected: idToDelete, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IReceptionDocumentWrite> receptionDocumentWriteServiceMock,
            LogicRemoveReceptionDocumentRequest request,
            LogicRemoveReceptionDocumentRequestHandler handler)
        {
            // Arrange
            var idToDelete = Guid.NewGuid();

            receptionDocumentWriteServiceMock.Setup(x => x.LogicRemoveAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<bool>>(result);
        }
    }
}
