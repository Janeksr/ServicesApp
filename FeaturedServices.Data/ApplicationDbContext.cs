using FeaturedServices.Common.Models;
using FeaturedServices.Data.Configurations.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeaturedServices.Data
{
    public class ApplicationDbContext : IdentityDbContext<Client>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.Entity<WorkerService>()
                   .HasKey(bc => new { bc.ServiceId, bc.WorkerId });
            builder.Entity<WorkerService>()
                .HasOne(bc => bc.Service)
                .WithMany(b => b.WorkerServices)
                .HasForeignKey(bc => bc.ServiceId);
            builder.Entity<WorkerService>()
                .HasOne(bc => bc.Worker)
                .WithMany(c => c.WorkerServices)
                .HasForeignKey(bc => bc.WorkerId);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkerService> WorkerServices { get; set; }


        public DbSet<ImageCompany> ImageCompanies { get; set; }
    }
}