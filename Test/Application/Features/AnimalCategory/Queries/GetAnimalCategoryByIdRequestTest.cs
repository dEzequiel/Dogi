﻿using Application.Features.AnimalCategory.Queries;
using Application.Service.Abstraction.Read;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Response;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Features.AnimalCategory.Queries
{
    public class GetAnimalCategoryByIdRequestTest
    {
        [Theory]
        [AutoMoqData]
        internal void RequestShouldSetIdDataProperty(int id)
        {
            // Act
            var request = new GetAnimalCategoryByIdRequest(id);
            // Assert
            Assert.Equal(expected: id, actual: request.Id);
        }

        [Theory]
        [AutoMoqData]
        internal async Task HandleShouldCallServiceAndReturnApiResponseDtoAsync(
            [Frozen] Mock<IAnimalCategoryReadService> animalCategoryReadMock,
            Domain.Entities.Shelter.AnimalCategory animalCategoryForGet,
            GetAnimalCategoryByIdRequest request,
            GetAnimalCategoryByIdRequestHandler handler)
        {
            // Arrange
            animalCategoryReadMock.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(animalCategoryForGet);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            Assert.IsType<ApiResponse<Domain.Entities.Shelter.AnimalCategory>>(result);
            animalCategoryReadMock.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}