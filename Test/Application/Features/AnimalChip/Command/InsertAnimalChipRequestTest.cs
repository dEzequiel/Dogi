using Application.Features.InsertAnimalChipRequest.Commands;
using Application.Service.Abstraction.Write;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Crosscuting.Api.DTOs.Response;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;

namespace Test.Application.Features.AnimalChip.Command
{
    public class InsertAnimalChipRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetAnmalDataProperty(Domain.Entities.AnimalChip data,
            AdminData adminData)
        {
            // Act
            var request = new InsertAnimalChipRequest(data, adminData);
            // Assert
            Assert.Equal(expected: data, actual: request.AnimalChipData);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IAnimalChipWrite> animalChipWriteMock,
            Domain.Entities.AnimalChip animalChipForGet,
            InsertAnimalChipRequest request,
            InsertAnimalChipRequestHandler handler)
        {
            // Arrange
            animalChipWriteMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.AnimalChip>(),
                                                      It.IsAny<AdminData>(),
                                                      It.IsAny<CancellationToken>()))
                .ReturnsAsync(animalChipForGet);
            
            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.AnimalChip>>(result);
            animalChipWriteMock.Verify(i => i.AddAsync(It.IsAny<Domain.Entities.AnimalChip>(),
                                                       It.IsAny<AdminData>(),
                                                       It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
