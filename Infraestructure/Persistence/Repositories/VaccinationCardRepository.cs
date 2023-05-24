using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class VaccinationCardRepository : IVaccinationCardRepository
    {
        private const string VACCINATION_CARD_NOT_FOUND = "VaccinationCard with id {0} not found.";
        protected DbSet<VaccinationCard> VaccinationCards;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public VaccinationCardRepository(ApplicationDbContext context)
        {
            VaccinationCards = context.Set<VaccinationCard>();
        }

        /// <inheritdoc/>
        public async Task AddAsync(VaccinationCard entity, AdminData admin, CancellationToken ct = default)
        {
            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;

            await VaccinationCards.AddAsync(entity, ct);
        }

        /// <inheritdoc/>
        public async Task AddAsync(VaccinationCard entity)
        {
            await VaccinationCards.AddAsync(entity);
        }

        /// <inheritdoc/>
        public Task AddRangeAsync(IEnumerable<VaccinationCard> entities)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<VaccinationCard>> FindAsync(Expression<Func<VaccinationCard, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<VaccinationCard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<VaccinationCard?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<VaccinationCard> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await VaccinationCards.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity is null)
                throw new DogiException(string.Format(VACCINATION_CARD_NOT_FOUND, id));

            return entity;
        }

        /// <inheritdoc/>
        public async Task<VaccinationCard> UpdateAsync(Guid id, string observations, AdminData admin, CancellationToken ct = default)
        {
            var entity = await VaccinationCards.FirstOrDefaultAsync(x => x.Id == id);

            entity.Observations = observations;

            return entity;
        }
    }
}
