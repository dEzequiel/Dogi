using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Infraestructure.Context;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Test.Infraestructure
{
    [Collection("ReceptionDocumentRepository")]
    public class ReceptionDocumentRepositoryTest
    {
        private readonly ApplicationDbContext _context;
        private readonly IReceptionDocumentRepository repository;

        /// <summary>
        /// Constructor. XUnit constructor run before each test.
        /// </summary>
        public ReceptionDocumentRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            repository = new ReceptionDocumentRepository(_context);
            Seed(_context);
        }

        [Fact]
        public async void Should_Get_Set_Of_Objects()
        {
            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.IsAssignableFrom<IList<ReceptionDocument>>(result);
        }

        private void Seed(ApplicationDbContext context)
        {
           // var CategoryId = Guid.Parse("1d5f841d-e020-4192-a0eb-77e97eb1b7d4");

           // var receptionDocuments = new List<ReceptionDocument>();

           // var reception = ReceptionDocument.Create(
           //     Guid.Parse("a06a5f34-58ac-41ec-bccb-9a8c38696bd2"),
           //     Guid.Parse("a06a5f34-58ac-41ec-bccb-9a8c38696bd2"),
           //     CategoryId,
           //     ((int)Sex.Male),
           //     false,
           //     "black",
           //     null,
           //     null,
           //     null
           //);

           // receptionDocuments.Add(reception.Value!);

           // context.ReceptionsDocuments.AddRange(receptionDocuments);
           // context.SaveChanges();
        }
    }
}
