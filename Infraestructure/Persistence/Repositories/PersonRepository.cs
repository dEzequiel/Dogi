using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Shelter;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected DbSet<Person> Persons;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="context"></param>
        public PersonRepository(ApplicationDbContext context)
        {
            Persons = context.Set<Person>();
        }

        ///<inheritdoc />
        public async Task AddAsync(Person entity, CancellationToken ct = default)
        {
            entity.Created = DateTime.Now;

            await Persons.AddAsync(entity, ct);
        }

        ///<inheritdoc />
        public async Task AddAsync(Person entity)
        {
            await Persons.AddAsync(entity);
        }

        ///<inheritdoc />
        public Task AddRangeAsync(IEnumerable<Person> entities)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public async Task<Person> BanAsync(string id, CancellationToken ct = default)
        {
            var person = await Persons.FirstOrDefaultAsync(x => x.PersonIdentifier == id, ct);

            if (person is null)
                throw new DogiException($"Person with id {id} not found.");

            person.IsBan = true;

            return person;
        }

        ///<inheritdoc />
        public async Task<Person> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
        {
            var entity = await Persons.FirstOrDefaultAsync(x => x.UserId == userId, ct);

            if (entity is null)
            {
                throw new DogiException("Person not found");
            }

            return entity;
        }

        ///<inheritdoc />
        public Task<IEnumerable<Person>> FindAsync(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc />
        public Task<Person?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}