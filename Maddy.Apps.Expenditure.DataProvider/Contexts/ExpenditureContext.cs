using Maddy.Apps.Expenditure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maddy.Apps.Expenditure.DataProvider.Contexts
{
    public class ExpenditureContext : DbContext
    {
        public ExpenditureContext(DbContextOptions<ExpenditureContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenditureType> ExpenditureTypes { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<Filter> Filters { get; set; }

        public DbSet<Entities.Expenditure> Expenditures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenditureFilter>(expenditureFilter =>
            {
               //expenditureFilter.HasKey(s => new { s.ExpenditureId, s.FilterId });
                expenditureFilter.Property(s => s.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
