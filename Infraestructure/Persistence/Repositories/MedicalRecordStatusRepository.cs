using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Support;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class MedicalRecordStatusRepository : IMedicalRecordStatusRepository
    {
        private const string MEDICAL_RECORD_STATUS_NOT_FOUND = "MedicalRecordStatus with id {0} not found.";
        protected DbSet<MedicalRecordStatus> MedicalRecordStatuses;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public MedicalRecordStatusRepository(ApplicationDbContext context)
        {
            MedicalRecordStatuses = context.Set<MedicalRecordStatus>();
        }

        /// <inheritdoc/>
        public async Task<MedicalRecordStatus> GetAsync(int id, CancellationToken ct = default)
        {
            var entity = await MedicalRecordStatuses.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new DogiException(MEDICAL_RECORD_STATUS_NOT_FOUND);
            }

            return entity;
        }
    }
}
