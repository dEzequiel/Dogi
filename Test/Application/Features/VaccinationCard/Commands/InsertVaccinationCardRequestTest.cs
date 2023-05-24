using Application.Features.VaccinationCard.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.VaccinationCard.Commands
{
    public class InsertVaccinationCardRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetVaccinationCardDataProperty(Domain.Entities.VaccinationCard vaccinationCardAdd,
                       AdminData adminData)
        {
            // Act
            var request = new InsertVaccinationCardRequest(vaccinationCardAdd, adminData);
            // Assert
            Assert.Equal(expected: vaccinationCardAdd, actual: request.VaccinationCardData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDto(
            [Frozen] Mock<IVaccinationCardWriteService> vaccinationCardWriteServiceMock,
            Domain.Entities.VaccinationCard vaccinationCardForGet,
            InsertVaccinationCardRequest request,
            InsertVaccinationCardRequestHandler handler)
        {
            // Arrange
            vaccinationCardWriteServiceMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.VaccinationCard>(),
                                                                  It.IsAny<AdminData>(),
                                                                  It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccinationCardForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.VaccinationCard>>(result);
            vaccinationCardWriteServiceMock.Verify(i => i.AddAsync(It.IsAny<Domain.Entities.VaccinationCard>(),
                                                                   It.IsAny<AdminData>(),
                                                                   It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
