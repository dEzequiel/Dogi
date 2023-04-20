using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crosscuting.Api.DTOs.Response;

namespace Domain.Interfaces.Repositories
{
    public interface IReceptionDocumentRepository : IRepository<ReceptionDocument>
    {
        /// <summary>
        /// Get all ReceptionDocuments with pagination properties.
        /// </summary>
        /// <param name="paginated"></param>
        /// <returns></returns>
        Task<IEnumerable<ReceptionDocument>> GetAllPaginatedAsync(PaginatedRequest paginated);
    }
}
