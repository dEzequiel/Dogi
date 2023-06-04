using Application.Service.Interfaces;
using Crosscuting.Api;
using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionApplicationRepository : IRepository<AdoptionApplication>
{
    /// <summary>
    /// Add new Adoption application.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="userData"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task AddAsync(AdoptionApplication entity, UserData userData, CancellationToken ct = default);
}