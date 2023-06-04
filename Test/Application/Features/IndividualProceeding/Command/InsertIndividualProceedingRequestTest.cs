using Application.Features.IndividualPro.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.IndividualProceeding.Command
{
    public class InsertIndividualProceedingRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIndividualProceedingDataProperty(
            Domain.Entities.Shelter.IndividualProceeding data,
            AdminData adminData)
        {
            // Act
            var request = new InsertIndividualProceedingRequest(data, adminData);
            // Assert
            Assert.Equal(expected: data, actual: request.IndividualProceedingData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IIndividualProceedingWriteService> individualProceedingWriteServiceMock,
            Domain.Entities.Shelter.IndividualProceeding individualProceedingForGet,
            InsertIndividualProceedingRequest request,
            InsertIndividualProceedingRequestHandler handler)
        {
            // Arrange
            individualProceedingWriteServiceMock.Setup(x =>
                    x.AddAsync(It.IsAny<Domain.Entities.Shelter.IndividualProceeding>(),
                        It.IsAny<AdminData>(),
                        It.IsAny<CancellationToken>()))
                .ReturnsAsync(individualProceedingForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.Shelter.IndividualProceeding>>(result);
            individualProceedingWriteServiceMock.Verify(i =>
                i.AddAsync(It.IsAny<Domain.Entities.Shelter.IndividualProceeding>(),
                    It.IsAny<AdminData>(),
                    It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}