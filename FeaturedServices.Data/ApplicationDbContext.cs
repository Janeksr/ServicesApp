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

            builder.Entity<Worker_Service>()
                .HasOne(bc => bc.Service)
                .WithMany(b => b.Workers_Services)
                .HasForeignKey(bc => bc.ServiceId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Worker_Service>()
                .HasOne(bc => bc.Worker)
                .WithMany(c => c.Workers_Services)
                .HasForeignKey(bc => bc.WorkerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker_Service> Workers_Services { get; set; }


        public DbSet<ImageCompany> ImageCompanies { get; set; }
    }
}