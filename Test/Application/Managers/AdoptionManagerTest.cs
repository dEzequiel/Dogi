using Application.Features.AdoptionApplication.Commands;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Adoption;
using MediatR;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Managers;

public class AdoptionManagerTest
{
    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldCreateAdoptionApplicationAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            AdoptionApplication adoptionApplicationInput,
            UserData userData,
            ApiResponse<AdoptionApplication> adoptionApplicationApiResponse,
            AdoptionManager sut)
    {
        // Arrange
        var adoptionPendingIdToApply = Guid.NewGuid();

        mediatorMock.Setup(x => x.Send(It.IsAny<InsertAdoptionApplicationRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(adoptionApplicationApiResponse);

        // Act
        var result = await sut.RegisterAdoptionApplication(adoptionPendingIdToApply,
            adoptionApplicationInput, userData);

        // Arrange
        Assert.NotNull(result);
        Assert.IsType<AdoptionApplication>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<InsertAdoptionApplicationRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}