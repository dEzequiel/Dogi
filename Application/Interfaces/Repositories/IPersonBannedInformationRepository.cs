using Application.Service.Interfaces;
using Crosscuting.Api.DTOs;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IPersonBannedInformationRepository : IRepository<PersonBannedInformation>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(PersonBannedInformation entity, AdminData adminData, CancellationToken ct = default);
    }
}
