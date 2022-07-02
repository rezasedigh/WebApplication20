using Microsoft.EntityFrameworkCore;
using Sahra.jobManager.entity;

namespace Sahra.jobManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Coravel_JobHistoryEntity> JobHistoryEntity { get; set; }
        public DbSet<Coravel_ScheduledJobHistoryEntity> ScheduledJobHistoryEntity { get; set; }
        public DbSet<Coravel_ScheduledJobsEntity> ScheduledJobsEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Coravel_JobHistoryEntity).Assembly);
        }

    }
}
