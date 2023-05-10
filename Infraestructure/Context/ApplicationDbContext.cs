using Domain.Entities;
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
        public DbSet<ReceptionDocument> ReceptionDocument { get; set; }
        public DbSet<AnimalChip> AnimalChip { get; set; }
        public DbSet<IndividualProceeding> IndividualProceeding { get; set; }
        
        // Support Tables
        public DbSet<Sex> Sex { get; set; }
        public DbSet<ProceedingStatus> ProceedingStatus { get; set; }
        public DbSet<AnimalCategory> AnimalCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ReceptionDocumentTypeConfiguration().Configure(modelBuilder.Entity<ReceptionDocument>());
            new AnimalChipTypeConfiguration().Configure(modelBuilder.Entity<AnimalChip>());
            new IndividualProceedingTypeConfiguration().Configure(modelBuilder.Entity<IndividualProceeding>());
            new SexTypeConfiguration().Configure(modelBuilder.Entity<Sex>());
            new AnimalCategoryTypeConfiguration().Configure(modelBuilder.Entity<AnimalCategory>());
            new ProceedingStatusTypeConfiguration().Configure(modelBuilder.Entity<ProceedingStatus>());
        }
    }
}
