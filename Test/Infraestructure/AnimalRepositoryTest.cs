using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Infraestructure.Context;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.Infraestructure
{
    [Collection("AnimalRepository")]
    public class AnimalRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IAnimalRepository repository;

        /// <summary>
        /// Constructor. XUnit constructor run before each test.
        /// </summary>
        public AnimalRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            repository = new AnimalRepository(_context);
            Seed(_context);
        }

        [Fact]
        public async void Should_Get_All_Animals()
        {
            // Arrange
            var firstAnimalReceptionDocumentId = Guid.Parse("1df77886-c181-4f5a-b15a-18ff0c67992a");
            var secondAnimalReceptionDocumentId = Guid.Parse("1ce41215-398e-4b0c-b4d2-5d6c3fb7b397");

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.IsAssignableFrom<IList<Animal>>(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(firstAnimalReceptionDocumentId, result.FirstOrDefault()!.ReceptionDocumentId);
            Assert.Equal(secondAnimalReceptionDocumentId, result.Where(x => x.ReceptionDocumentId == secondAnimalReceptionDocumentId)
                                                                .First().ReceptionDocumentId);
        }

        private void Seed(ApplicationDbContext context)
        {
            var firstAnimalReceptionDocument = ReceptionDocument.Create(
                Guid.Parse("1df77886-c181-4f5a-b15a-18ff0c67992a"),
                Guid.Parse("96b1c876-eaa6-4f56-aca9-53f69d050a4e"),
                Guid.Parse("9c3df3fe-15e0-4004-b1a3-f02cef4ddcf2"),
                ((int)Sex.Male),
                false,
                "Black",
                "Broken leg",
                "Test Street No. 1",
                DateTime.Now).Value;


            var firstAnimal = Animal.Create(
                Guid.Parse("be4242b3-14a2-4f69-952a-53990f380441"),
                firstAnimalReceptionDocument!.Id,
                "Tom",
                14,
                "Black");

            var secondAnimalReceptionDocument = ReceptionDocument.Create(
                Guid.Parse("1ce41215-398e-4b0c-b4d2-5d6c3fb7b397"),
                Guid.Parse("489badaa-834a-4ae1-9f6e-a25ea7c7a7ea"),
                Guid.Parse("9c3df3fe-15e0-4004-b1a3-f02cef4ddcf2"),
                ((int)Sex.Male),
                false,
                "Brown",
                "Suffer anxiety attack",
                "Test Street No. 1",
                DateTime.Now).Value;

            var secondAnimal = Animal.Create(
                Guid.Parse("78bf53ce-413e-4593-ab91-9f691722a1ed"),
                secondAnimalReceptionDocument!.Id,
                "Tom",
                14,
                "Black");

            var animals = new List<Animal>();

            animals.Add(firstAnimal.Value);
            animals.Add(secondAnimal.Value);

            context.Animals.AddRange(animals);
            context.SaveChanges();
        }
    }
}
