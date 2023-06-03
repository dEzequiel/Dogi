using Application.Interfaces.Repositories;
using Domain.Entities.Shelter;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalCategoryRepository : IAnimalCategoryRepository
    {
        private const string ANIMAL_CATEGORY_NOT_FOUND = "Animal category with id {0} not found.";
        protected DbSet<AnimalCategory> AnimalCategoryAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AnimalCategoryRepository(ApplicationDbContext context)
        {
            AnimalCategoryAll = context.Set<AnimalCategory>();
        }

        ///<inheritdoc />
        public async Task<AnimalCategory?> GetAsync(int id)
        {
            return await AnimalCategoryAll.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}