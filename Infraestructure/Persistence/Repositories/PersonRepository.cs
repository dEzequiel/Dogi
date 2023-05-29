using Application.Interfaces.Repositories;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
