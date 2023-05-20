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
    public class InsertRegisterInformationRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetRegisterInformationDataProperty(RegisterInformation documentDataForAdd,
            AdminData adminData)
        {
            // Act
            var request = new InsertRegisterInformationRequest(documentDataForAdd, adminData);
            // Assert
            Assert.Equal(expected: documentDataForAdd, actual: request.Data);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallManagerServiceWhenAnimalHasNoChipAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IWelcomeManager> welcomeManagerWriteServiceMock,
            RegisterInformation registerInformationGet,
            InsertRegisterInformationRequest request,
            InsertRegisterInformationRequestHandler handler)
        {
            // Arrange
            request.Data.ReceptionDocument.HasChip = false;

            welcomeManagerWriteServiceMock.Setup(x => x.RegisterAnimal(
                It.IsAny<RegisterInformation>(),
                It.IsAny<AdminData>()))
                .ReturnsAsync(registerInformationGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<RegisterInformation>>(result);
            welcomeManagerWriteServiceMock.Verify(i => i.RegisterAnimal(
                               It.IsAny<RegisterInformation>(),
                               It.IsAny<AdminData>()), Times.Once());

        }
    }


}