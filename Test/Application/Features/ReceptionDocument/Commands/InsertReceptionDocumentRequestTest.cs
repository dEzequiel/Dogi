﻿using Application.Features.ReceptionDocument.Commands;
using Application.Service.Abstraction;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.ReceptionDocument.Commands
{
    public class InsertReceptionDocumentRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetReceptionDocumentDataProperty(
            Domain.Entities.Shelter.ReceptionDocument documentDataForAdd,
            AdminData adminData)
        {
            // Act
            var request = new InsertReceptionDocumentRequest(documentDataForAdd, adminData);
            // Assert
            Assert.Equal(expected: documentDataForAdd, actual: request.ReceptionDocumentData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IReceptionDocumentWriteService> receptionDocumentWriteServiceMock,
            Domain.Entities.Shelter.ReceptionDocument documentDataForGet,
            InsertReceptionDocumentRequest request,
            InsertReceptionDocumentRequestHandler handler)
        {
            // Arrange
            receptionDocumentWriteServiceMock.Setup(x =>
                    x.AddAsync(It.IsAny<Domain.Entities.Shelter.ReceptionDocument>(),
                        It.IsAny<AdminData>(),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(documentDataForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.Shelter.ReceptionDocument>>(result);
        }
    }
}