using Application.DTOs.VeterinaryManager;
using Crosscuting.Api.DTOs;

using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Managers.Abstraction
{
    public interface IVeterinaryManager : IApplicationServiceBase
    {
        /// <summary>
        /// Move an animal that is in the quarantine area to the waiting area for medical examination. 
        /// The status of the medical record is waiting. It is the first phase to enter a normal zone.
        /// </summary>
        /// <returns></returns>
        Task SetForMedicalRevision(IndividualProceeding individualProceeding);

        /// <summary>
        /// Mark as 'checked' the current medical record of the animal. This means the entry into the 
        /// animal area of the animal's category.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<InvidiualProceedingWithMedicalRecord> CheckMedicalRecord(Guid medicalRecordId, AdminData adminData, CancellationToken ct = default);
    }
}
