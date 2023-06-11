using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    /// <summary>
    /// Repository Pattern.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retrieve entity asynchronously by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(Guid id);

        /// <summary>
        ///  Retrieve all entities asynchronously.
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieve entity by identifier.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add entity asynchronously.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Add collection of entities asynchronously.
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }

}
