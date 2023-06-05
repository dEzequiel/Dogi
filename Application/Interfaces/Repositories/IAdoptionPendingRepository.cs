using Application.Service.Interfaces;
using Domain.Entities.Adoption;

namespace Application.Interfaces.Repositories;

public interface IAdoptionPendingRepository : IRepository<AdoptionPending>
{
}