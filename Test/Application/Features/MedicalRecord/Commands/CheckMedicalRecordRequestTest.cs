using Application.Features.MedicalRecord.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.MedicalRecord.Commands
{
    public class CheckMedicalRecordRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetMedicalRecordDataProperty(Domain.Entities.MedicalRecord medicalRecordAdd,
                       AdminData adminData)
        {
            // Act
            var request = new CheckMedicalRecordRequest(medicalRecordAdd, adminData);
            // Assert
            Assert.Equal(expected: medicalRecordAdd, actual: request.MedicalRecordData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IMedicalRecordWriteService> medicalRecordWriteServiceMock,
            Domain.Entities.MedicalRecord medicalRecordForGet,
            CheckMedicalRecordRequest request,
            CheckMedicalRecordRequestHandler handler)
        {
            // Arrange
            medicalRecordWriteServiceMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.MedicalRecord>(),
                                                                    It.IsAny<AdminData>(),
                                                                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(medicalRecordForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.MedicalRecord>>(result);
            medicalRecordWriteServiceMock.Verify(i => i.CheckAsync(It.IsAny<Domain.Entities.MedicalRecord>(),
                                                                 It.IsAny<AdminData>(),
                                                                 It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
