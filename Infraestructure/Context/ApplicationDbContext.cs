using Domain.Entities;
using Domain.Support;
using Infraestructure.EntityFrameworkConfiguration;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.Context
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Tables
        public DbSet<ReceptionDocument> ReceptionDocument { get; set; } = null!;
        public DbSet<AnimalChip> AnimalChip { get; set; } = null!;
        public DbSet<IndividualProceeding> IndividualProceeding { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<PersonBannedInformation> PersonBannedInformations { get; set; } = null!;
        public DbSet<Cage> Cages { get; set; } = null!;


        // Support Tables
        public DbSet<Sex> Sex { get; set; } = null!;
        public DbSet<IndividualProceedingStatus> ProceedingStatus { get; set; } = null!;
        public DbSet<AnimalCategory> AnimalCategory { get; set; } = null!;
        public DbSet<AnimalZone> AnimalZone { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ReceptionDocumentTypeConfiguration().Configure(modelBuilder.Entity<ReceptionDocument>());
            new AnimalChipTypeConfiguration().Configure(modelBuilder.Entity<AnimalChip>());
            new IndividualProceedingTypeConfiguration().Configure(modelBuilder.Entity<IndividualProceeding>());
            new SexTypeConfiguration().Configure(modelBuilder.Entity<Sex>());
            new AnimalCategoryTypeConfiguration().Configure(modelBuilder.Entity<AnimalCategory>());
            new IndividualProceedingStatusTypeConfiguration().Configure(modelBuilder.Entity<IndividualProceedingStatus>());
            new AnimalZoneTypeConfiguration().Configure(modelBuilder.Entity<AnimalZone>());
            new PersonTypeConfiguration().Configure(modelBuilder.Entity<Person>());
            new PersonBannedInformationTypeConfiguration().Configure(modelBuilder.Entity<PersonBannedInformation>());
            new CageTypeConfiguration().Configure(modelBuilder.Entity<Cage>());
        }
    }
}
