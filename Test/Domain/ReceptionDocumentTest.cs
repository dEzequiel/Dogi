using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;

namespace Test.Domain
{
    public class ReceptionDocumentTest
    {
        [Fact]
        public void Should_Create_ReceptionDocument()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Sex.Male,
                false,
                "black",
                null,
                null,
                null);

            // Assert
            Assert.True(sut.IsSuccess);
        }

        [Fact]
        public void Should_Fail_Create_When_Id_IsEmpty()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.Empty,
                Guid.NewGuid(),
                Guid.NewGuid(),
                Sex.Male,
                false,
                "black",
                null,
                null,
                null);

            // Assert
            Assert.False(sut.IsSuccess);
            Assert.Equal(DomainErrors.ReceptionDocument.ReceptionIdIsNullOrEmpty.Message, sut.Error.Message);
        }

        [Fact]
        public void Should_Fail_Create_When_Actor_IsEmpty()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.NewGuid(),
                Guid.Empty,
                Guid.NewGuid(),
                Sex.Male,
                false,
                "black",
                null,
                null,
                null);

            // Assert
            Assert.False(sut.IsSuccess);
            Assert.Equal(DomainErrors.ReceptionDocument.ActorIsNullOrEmpty.Message, sut.Error.Message);
        }

        [Fact]
        public void Should_Fail_Create_When_Category_IsEmpty()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.Empty,
                Sex.Male,
                false,
                "black",
                null,
                null,
                null);

            // Assert
            Assert.False(sut.IsSuccess);
            Assert.Equal(DomainErrors.ReceptionDocument.CategoryIsNullOrEmpty.Message, sut.Error.Message);
        }

        [Fact]
        public void Should_Fail_Create_When_Color_IsEmpty()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Sex.Male,
                false,
                string.Empty,
                null,
                null,
                null);

            // Assert
            Assert.False(sut.IsSuccess);
            Assert.Equal(DomainErrors.ReceptionDocument.ColorIsEmpty.Message, sut.Error.Message);
        }

        [Fact]
        public void Should_Fail_Create_When_Color_IsNull()
        {
            // Arrange and act
            var sut = ReceptionDocument.Create(
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid(),
                Sex.Male,
                false,
                null,
                null,
                null,
                null);

            // Assert
            Assert.False(sut.IsSuccess);
            Assert.Equal(DomainErrors.ReceptionDocument.ColorIsEmpty.Message, sut.Error.Message);
        }
    }
}