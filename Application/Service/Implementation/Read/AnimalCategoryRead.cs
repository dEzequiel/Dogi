using Application.Interfaces;
using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Read
{
    public class AnimalCategoryRead : IAnimalCategoryReadService
    {
        private readonly ILogger<AnimalCategoryRead> Logger;
        private readonly IUnitOfWork UnitOfWork;

        public AnimalCategoryRead(ILogger<AnimalCategoryRead> logger, IUnitOfWork unitOfWork)
        {
            UnitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
            Logger = Guard.Against.Null(logger, nameof(logger));
        }

        ///<inheritdoc />
        public async Task<AnimalCategory?> GetByIdAsync(int id)
        {
            Logger.LogInformation($"AnimalCategoryRead --> GetByIdAsync({id}) --> Start");

            Guard.Against.Null(id, nameof(id));

            var repository = UnitOfWork.AnimalCategoryRepository;

            var category = await repository.GetAsync(id);

            Logger.LogInformation($"AnimalCategoryRead --> GetByIdAsync --> End");

            return category;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}