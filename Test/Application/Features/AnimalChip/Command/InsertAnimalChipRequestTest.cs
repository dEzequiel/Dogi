using Application.Features.InsertAnimalChipRequest.Commands;
using Crosscuting.Api.DTOs;
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
    }
}
