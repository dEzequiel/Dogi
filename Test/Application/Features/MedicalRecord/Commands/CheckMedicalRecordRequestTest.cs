namespace Test.Application.Features.MedicalRecord.Commands
{
    public class CheckMedicalRecordRequestTest
    {
        //[Theory]
        //[AutoMoqData]
        //internal void RequestShouldSetMedicalRecordDataProperty(Domain.Entities.MedicalRecord medicalRecordAdd, AdminData adminData)
        //{
        //    // Arrange

        //    // Act
        //    var request = new CheckMedicalRecordRequest(medicalRecordAdd.Id, adminData);
        //    // Assert
        //    Assert.Equal(expected: medicalRecordAdd, actual: request.MedicalRecordData);
        //}

        //[Theory]
        //[AutoMoqData]
        //internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
        //    [Frozen] Mock<IMedicalRecordWriteService> medicalRecordWriteServiceMock,
        //    Domain.Entities.MedicalRecord medicalRecordForGet,
        //    CheckMedicalRecordRequest request,
        //    CheckMedicalRecordRequestHandler handler)
        //{
        //    // Arrange
        //    medicalRecordWriteServiceMock.Setup(x => x.CheckAsync(It.IsAny<Guid>(),
        //                                                            It.IsAny<AdminData>(),
        //                                                            It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(medicalRecordForGet);

        //    // Act
        //    var result = await handler.Handle(request, default);

        //    // Assert
        //    Assert.IsType<ApiResponse<Domain.Entities.MedicalRecord>>(result);
        //    medicalRecordWriteServiceMock.Verify(i => i.CheckAsync(It.IsAny<Guid>(),
        //                                                         It.IsAny<AdminData>(),
        //                                                         It.IsAny<CancellationToken>()), Times.Once);
    }
}

