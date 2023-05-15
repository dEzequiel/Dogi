using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.WelcomeManager;
using Application.Features.WelcomeManagerFeature.Command;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.WelcomeManagerTest
{
    public class InsertReceptionDocumentWithAnimalOwnerInfoRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetReceptionDocumentDataProperty(ReceptionDocumentWithAnimalInformation documentDataForAdd,
            AdminData adminData)
        {
            // Act
            var request = new InsertReceptionDocumentWithAnimalOwnerInfoRequest(documentDataForAdd, adminData);
            // Assert
            Assert.Equal(expected: documentDataForAdd, actual: request.Data);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldManagerAndReturnApiResponseDtoAsync([Frozen] Mock<IWelcomeManager> welcomeManagerWriteServiceMock,
            RegisterInformation registerInformationGet,
            AdminData adminData,
            InsertReceptionDocumentWithAnimalOwnerInfoRequest request,
            InsertReceptionDocumentWithAnimalOwnerInfoRequestHandler handler)
        {
            // Arrange
            welcomeManagerWriteServiceMock.Setup(x => x.AddAnimalWithOwnerInfo(
                It.IsAny<ReceptionDocumentWithAnimalInformation>(),
                It.IsAny<AdminData>()))
                .ReturnsAsync(registerInformationGet);
            
            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<RegisterInformation>>(result);
        }
    }


}