using Application.Features.ReceptionDocument.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.ReceptionDocument.Queries.ReceptionDocument;

public class GetReceptionDocumentByIdRequestTest
{
    [Theory]
    [AutoMoqData]
    internal void RequestShouldSetIdDataProperty(Guid id)
    {
        // Act
        var request = new GetReceptionDocumentByIdRequest(id);
        // Assert
        Assert.Equal(expected: id, actual: request.Id);
    }

    [Theory]
    [AutoMoqData]
    internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
        [Frozen] Mock<IReceptionDocumentRead> receptionDocumentReadServiceMock,
        Domain.Entities.ReceptionDocument documentForGet,
        GetReceptionDocumentByIdRequest request,
        GetReceptionDocumentByIdRequestHandler handler)
    {
        // Arrange
        receptionDocumentReadServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(documentForGet);
        
        // Act
        var result = await handler.Handle(request, default);

        // Assert
        Assert.IsType<ApiResponse<Domain.Entities.ReceptionDocument>>(result);
        receptionDocumentReadServiceMock.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()));
    }
}