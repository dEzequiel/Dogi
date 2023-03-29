using Infraestructure.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
