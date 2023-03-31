using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.Context
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext :  DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Tables
        public DbSet<ReceptionDocument> ReceptionsDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceptionDocument>();
        }
    }
}
