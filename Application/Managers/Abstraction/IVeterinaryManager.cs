﻿using Application.DTOs.VeterinaryManager;
using Crosscuting.Api.DTOs;

using Crosscuting.Base.Interfaces;
using Domain.Entities;

namespace Application.Managers.Abstraction
{
    public interface IVeterinaryManager : IApplicationServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IndividualProceedingWithMedicalRecord> CreateMedicalRecord(Guid individualProceedingId, MedicalRecord medicalRecord, IEnumerable<Guid>? vaccines, AdminData adminData, CancellationToken ct = default);

        /// <summary>
        /// Mark as 'checked' the current medical record of the animal. This means the first step for the entry into the 
        /// animal area of the animal's category.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<IndividualProceedingWithMedicalRecord> CheckMedicalRecord(Guid medicalRecordId, string? observations, AdminData adminData, CancellationToken ct = default);

        /// <summary>
        /// Mark as 'closed' the current medical record of the animal. This means the entry
        /// into the animal area of the animal's category.
        /// </summary>
        /// <param name="medicalRecordId"></param>
        /// <param name="AdminData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceedingWithMedicalRecord> CloseMedicalRecord(Guid medicalRecordId, string conclusions, AdminData AdminData, CancellationToken ct = default);

        /// <summary>
        /// Assign a vaccine to an individual file. This marks the vaccine as pending in the vaccine card.
        /// </summary>
        /// <param name="individualProceedingId"></param>
        /// <param name="adminData"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceedingWithVaccinationCard> AssignPendingVaccine(Guid vaccinationCardId, Guid vaccineId, AdminData adminData, CancellationToken ct = default);
    }
}
