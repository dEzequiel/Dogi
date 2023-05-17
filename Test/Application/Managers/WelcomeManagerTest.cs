using Application.DTOs.WelcomeManager;
using Application.Features.IndividualPro.Commands;
using Application.Features.InsertAnimalChipRequest.Commands;
using Application.Features.ReceptionDocument.Commands;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities;
using MediatR;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Managers
{
    public class WelcomeManagerTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldRegisterInformationAboutReceptionDocumentAndIndividualProceedingIfAnimalHasNoChipAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            RegisterInformation registerInformation,
            AdminData adminData,
            WelcomeManager sut)
        {
            // Arrange
            registerInformation.ReceptionDocument.HasChip = false;

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            // Act
            var result = await sut.RegisterAnimal(registerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldRegisterInformationAboutReceptionDocumentIndividualProceedingAndAnimalChipIfAnimalHasChipAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            ApiResponse<ReceptionDocument> receptionDocumentApiResponse,
            ApiResponse<IndividualProceeding> individualProceedingApiResponse,
            ApiResponse<AnimalChip> animalChipApiResponse,
            RegisterInformation registerInformation,
            AdminData adminData,
            WelcomeManager sut)
        {
            // Arrange
            registerInformation.ReceptionDocument.HasChip = true;

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                           It.IsAny<CancellationToken>()))
                .ReturnsAsync(receptionDocumentApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingApiResponse);

            mediatorMock.Setup(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                               It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalChipApiResponse);

            // Act
            var result = await sut.RegisterAnimal(registerInformation, adminData);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<RegisterInformation>(result);
            mediatorMock.Verify(x => x.Send(It.IsAny<InsertReceptionDocumentRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertIndividualProceedingRequest>(),
                                            It.IsAny<CancellationToken>()), Times.Once);

            mediatorMock.Verify(x => x.Send(It.IsAny<InsertAnimalChipRequest>(),
                                It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
