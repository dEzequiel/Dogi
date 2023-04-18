﻿using Application.DTOs.ReceptionDocument;
using Application.Features.ReceptionDocument.Commands;
using Application.Service.Abstraction;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.ReceptionDocument.Commands
{
    public class InsertReceptionDocumentRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetReceptionDocumentDataProperty(ReceptionDocumentForAdd documentDataForAdd)
        {
            // Act
            var request = new InsertReceptionDocumentRequest(documentDataForAdd);
            // Assert
            Assert.Equal(expected: documentDataForAdd, actual: request.ReceptionDocumentData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IReceptionDocumentWrite> receptionDocumentWriteServiceMock,
            ReceptionDocumentForGet documentDataForGet,
            InsertReceptionDocumentRequest request,
            InsertReceptionDocumentRequestHandler handler)
        {
            // Arrange
            receptionDocumentWriteServiceMock.Setup(x => x.AddAsync(It.IsAny<ReceptionDocumentForAdd>()))
                .ReturnsAsync(documentDataForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<ReceptionDocumentForGet>>(result);
            receptionDocumentWriteServiceMock.Verify(x => x.AddAsync(It.IsAny<ReceptionDocumentForAdd>()));
        } 
    }
}
