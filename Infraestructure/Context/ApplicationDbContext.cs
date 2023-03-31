using Domain.Entities;
using Infraestructure.EntityFrameworkConfiguration;
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
        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceptionDocument>();
            new AnimalTypeConfiguration().Configure(modelBuilder.Entity<Animal>());
        }
    }
}
