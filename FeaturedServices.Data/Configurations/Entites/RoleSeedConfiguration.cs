using FeaturedServices.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeaturedServices.Data.Configurations.Entites
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                },
                new IdentityRole
                {
                    Id = "626a4a0c-b21e-a9ab-9e32-144f20a1bced",
                    Name = Roles.Company,
                    NormalizedName = Roles.Company.ToUpper()
                },
                new IdentityRole
                {
                    Id = "6261baec-128e-a0ab-ae32-164f20a1bced",
                    Name = Roles.CompanyCreated,
                    NormalizedName = Roles.CompanyCreated.ToUpper()
                }
                );
        }
    }
}