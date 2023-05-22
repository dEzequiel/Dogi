﻿using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities;
using Domain.Enums;

namespace Application.Service.Abstraction.Write
{
    /// <summary>
    /// IndividualProceeding Write Service Definition.
    /// </summary>
    public interface IIndividualProceedingWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new IndividualProceeding.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> AddAsync(IndividualProceeding entity, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Soft delete existing IndividualProceeding.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> LogicRemoveAsync(Guid id, AdminData admin, CancellationToken ct = default);

        /// <summary>
        /// Update existing IndividualProceeding status.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <param name="admin"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IndividualProceeding> UpdateAsync(Guid id, IndividualProceedingStatus status, AdminData admin, CancellationToken ct = default);

    }
}
