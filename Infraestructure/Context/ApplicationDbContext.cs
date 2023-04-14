using Domain.Entities;
using Domain.Support;
using Domain.Support;
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
        public DbSet<AnimalChip> AnimalChips { get; set; }
        public DbSet<IndividualProceeding> IndividualProceedings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ReceptionDocumentTypeConfiguration().Configure(modelBuilder.Entity<ReceptionDocument>());
            new AnimalTypeConfiguration().Configure(modelBuilder.Entity<Animal>());
            new AnimalChipTypeConfiguration().Configure(modelBuilder.Entity<AnimalChip>());
            new IndividualProceedingTypeConfiguration().Configure(modelBuilder.Entity<IndividualProceeding>());
            new SexTypeConfiguration().Configure(modelBuilder.Entity<Sex>());
            new AnimalCategoryTypeConfiguration().Configure(modelBuilder.Entity<AnimalCategory>());
            new ProceedingStatusTypeConfiguration().Configure(modelBuilder.Entity<ProceedingStatus>());
        }
    }
}
