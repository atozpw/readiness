using Microsoft.EntityFrameworkCore;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Plan> Plans { get; set; } = null!;
        public DbSet<Domain> Domains { get; set; } = null!;
        public DbSet<PlanType> PlanTypes { get; set; } = null!;
        public DbSet<DraftResponse> DraftResponses { get; set; } = null!;
        public DbSet<PlanDocument> PlanDocuments { get; set; } = null!;
        public DbSet<PriorityAction> PriorityActions { get; set; } = null!;
        public DbSet<PriorityActionDetail> PriorityActionDetails { get; set; } = null!;
        public DbSet<OnMerge> OnMerges { get; set; } = null!;
        public DbSet<MergeDraftResponse> MergeDraftResponses { get; set; } = null!;

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}