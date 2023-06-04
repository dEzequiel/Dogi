using Application.Interfaces;
using Application.Service.Abstraction.Write;
using Ardalis.GuardClauses;
using Domain.Entities.Shelter;
using Microsoft.Extensions.Logging;

namespace Application.Service.Implementation.Write
{
    public class PersonWrite : IPersonWriteService
    {
        private readonly ILogger<PersonWrite> Logger;
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public PersonWrite(ILogger<PersonWrite> logger, IUnitOfWork unitOfWork)
        {
            Logger = Guard.Against.Null(logger);
            UnitOfWork = Guard.Against.Null(unitOfWork);
        }

        ///<inheritdoc />
        public async Task<Person> AddAsync(Person entity, CancellationToken ct = default)
        {
            Logger.LogInformation("PersonWrite --> AddAsync --> Start");

            Guard.Against.Null(entity, nameof(entity));
            Guard.Against.NullOrEmpty(entity.PersonIdentifier, nameof(entity.PersonIdentifier));
            Guard.Against.NullOrEmpty(entity.Name, nameof(entity.Name));
            Guard.Against.NullOrEmpty(entity.Contact, nameof(entity.Contact));

            var repository = UnitOfWork.PersonRepository;

            await repository.AddAsync(entity);

            await UnitOfWork.CompleteAsync(ct);

            Logger.LogInformation("PersonWrite --> AddAsync --> End");

            return entity;
        }

        ///<inheritdoc />
        public async Task<Person> BanAsync(string id, CancellationToken ct = default)
        {
            Logger.LogInformation("PersonWrite --> BanPersonAsync --> Start");

            Guard.Against.NullOrEmpty(id, nameof(id));

            var repository = UnitOfWork.PersonRepository;

            var person = await repository.BanAsync(id);

            Logger.LogInformation("PersonWrite --> BanPersonAsync --> End");

            return person;
        }

        ///<inheritdoc />
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}