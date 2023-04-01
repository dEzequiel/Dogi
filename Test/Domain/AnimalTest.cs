using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils.Attributes;
using Xunit;

namespace Test.Domain
{
    public class AnimalTest
    {
        [Theory]
        [AutoMoqData]
        public void Should_Create_Animal(
            ReceptionDocument receptionDocument)
        {
            // Arrange
            var sut = Animal.Create(
                Guid.NewGuid(),
                receptionDocument.Id,
                "Test",
                1,
                "Black");
           
            // Assert
            Assert.True(sut.IsSuccess);
            Assert.Equal(sut.Value.ReceptionDocumentId, receptionDocument.Id);
        }
    }
}
