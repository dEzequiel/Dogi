using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Repositories
{
    internal class AnimalChipOwnerRepository : IAnimalChipOwnerRepository
    {
        /// <summary>
        /// Attributes.
        /// </summary>
        protected DbSet<AnimalChipOwner> _animalChipOwners;

        /// <summary>
        /// Messages.
        /// </summary>
        private const string INDIVIDUAL_PROCEEDING_NOT_FOUND = "IndividualProceeding with id {0} not found.";

        public AnimalChipOwnerRepository(ApplicationDbContext context)
        {
            _animalChipOwners = context.Set<AnimalChipOwner>();
        }

        public Task AddAsync(AnimalChipOwner entity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(AnimalChipOwner entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<AnimalChipOwner> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalChipOwner>> FindAsync(Expression<Func<AnimalChipOwner, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalChipOwner>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnimalChipOwner>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalChipOwner> GetAsync(Guid id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalChipOwner?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, AnimalChipOwner newEntity, AdminData admin, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
