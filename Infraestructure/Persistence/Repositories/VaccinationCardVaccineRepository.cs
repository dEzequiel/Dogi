using Application.Interfaces.Repositories;
using Crosscuting.Api.DTOs;
using Crosscuting.Base.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infraestructure.Persistence.Repositories
{
    public class VaccinationCardVaccineRepository : IVaccinationCardVaccineRepository
    {
        private const string VACCINATION_CARD_VACCINE_NOT_FOUND = "VaccinationCardVaccine with id {0} not found.";
        private const string VACCINATION_CARD_VACCINE_ALREADY_DONE = "VaccinationCardVaccine with id {0} already done.";
        private const string VACCINATION_CARD_VACCINE_ALREADY_ADDED = "Vaccine with id {0} already added in VaccinationCard with id {1}.";
        private const string VACCINATION_CARD_VACCINE_MEMBERS_NOT_FOUND = "Vaccine with id {0} and VaccinationCard with id {1} not found.";

        protected DbSet<VaccinationCardVaccine> VaccinationCardVaccines;

        /// <summary>
        /// Constructor;
        /// </summary>
        /// <param name="context"></param>
        public VaccinationCardVaccineRepository(ApplicationDbContext context)
        {
            VaccinationCardVaccines = context.Set<VaccinationCardVaccine>();
        }

        ///<inheritdoc />
        public async Task AddAsync(VaccinationCardVaccine entity, AdminData admin, CancellationToken ct = default)
        {
            var vaccineAlreadyAssigned = await VaccinationCardVaccines.FirstOrDefaultAsync(x => x.VaccineId == entity.VaccineId && x.VaccinationCardId == entity.VaccinationCardId);

            if (vaccineAlreadyAssigned != null)
            {
                throw new DogiException(string.Format(VACCINATION_CARD_VACCINE_ALREADY_ADDED, entity.VaccineId, entity.VaccinationCardId));
            }

            entity.Created = DateTime.UtcNow;
            entity.CreatedBy = admin.Email;
            entity.VaccineStatusId = ((int)VaccineStatus.Pending);

            await VaccinationCardVaccines.AddAsync(entity, ct);

        }

        ///<inheritdoc />
        public async Task AddAsync(VaccinationCardVaccine entity)
        {
            await VaccinationCardVaccines.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<Domain.Entities.VaccinationCardVaccine> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.VaccinationCardVaccine>> FindAsync(Expression<Func<Domain.Entities.VaccinationCardVaccine, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Entities.VaccinationCardVaccine>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.VaccinationCardVaccine?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<VaccinationCardVaccine> VaccineAsync(Guid vaccineCardId, Guid vaccineId, CancellationToken cancellationToken = default)
        {
            var entity = await VaccinationCardVaccines.FirstOrDefaultAsync(x => x.VaccinationCardId == vaccineCardId && x.VaccineId == vaccineId, cancellationToken);

            if (entity is null)
            {
                throw new DogiException(string.Format(VACCINATION_CARD_VACCINE_MEMBERS_NOT_FOUND, vaccineId, vaccineCardId));
            }

            entity.VaccineStatusId = ((int)VaccineStatus.Done);

            return entity;
        }
    }
}
