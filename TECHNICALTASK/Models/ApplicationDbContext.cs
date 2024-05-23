using Microsoft.EntityFrameworkCore;

namespace TECHNICALTASK.Models
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<MasterTable> Masters { get; set; }
        public DbSet<DetailsTable> Details { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);     
        }
    }
}
