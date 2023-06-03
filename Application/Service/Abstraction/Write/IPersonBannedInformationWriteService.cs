using Crosscuting.Api.DTOs;
using Crosscuting.Base.Interfaces;
using Domain.Entities.Shelter;

namespace Application.Service.Abstraction.Write
{
    public interface IPersonBannedInformationWriteService : IApplicationServiceBase
    {
        /// <summary>
        /// Add new PersonBannedInformation.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<PersonBannedInformation> AddAsync(PersonBannedInformation entity, AdminData adminData,
            CancellationToken ct = default);
    }
}