using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Enums;
using Crosscuting.Base.Exceptions;

namespace Infraestructure.Persistence.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        private const string ANIMAL_NOT_FOUND = "Animal with id {0} not found.";
        protected IQueryable<Animal> _animals;
        protected DbSet<Animal> _animalsAll;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AnimalRepository(ApplicationDbContext context)
        {
            _animalsAll = context.Set<Animal>();
            _animals = _animalsAll!.Where(x => !x.IsDeleted);
        }

        /// <inheritdoc/>
        public async Task AddAsync(Animal entity)
        {
            await _animalsAll.AddAsync(entity);
        }

        /// <inheritdoc/>
        public async Task AddAsync(Animal entity, AdminData admin, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;
            entity.IsDeleted = false;

            await _animalsAll.AddAsync(entity, ct); ;
        }

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<Animal> entities)
        {
            await _animalsAll.AddRangeAsync(entities);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> FindAsync(Expression<Func<Animal, bool>> predicate)
        {
            return await _animals.AsNoTracking().Where(predicate).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _animals.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> GetAllAsync(CancellationToken ct = default)
        {
            return await _animals.AsNoTracking().ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Animal>> GetAllFilterByCategoryAsync(AnimalCategory category, CancellationToken ct = default)
        {
            return await _animals.AsNoTracking()
                                .Where(x => x.AnimalCategoryId == ((int)category))
                                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Animal?> GetAsync(Guid id)
        {
            return await _animals.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            var entity = await _animals.SingleOrDefaultAsync(x => x.Id == id, ct);

            if (entity == null)
                throw new DogiException(string.Format(ANIMAL_NOT_FOUND, id));

            entity.IsDeleted = true;
            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = admin.Email;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Guid id, Animal entity, AdminData admin, CancellationToken ct = default)
        {
            var animal = await _animals.FirstOrDefaultAsync(x => x.Id == id);

            if (animal is null)
                throw new DogiException(string.Format(ANIMAL_NOT_FOUND, id));

            animal.LastModified = DateTime.UtcNow;
            animal.LastModifiedBy = admin.Email;

            animal.Age = entity.Age;
            animal.AnimalCategoryId = entity.AnimalCategoryId;
            animal.Color = entity.Color;
            animal.Name = entity.Name;
            animal.SexId = entity.SexId;
        }
    }
}
