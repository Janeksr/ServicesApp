using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeaturedServices.Data
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0f6121ad-b6be-49ff-9d02-6c442008ace4",
                    UserId = "408121ad-b63e-49ff-1d02-6c221af8ace4"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "0f61aaac-b21e-a9ff-9e02-64432001abe4",
                    UserId = "fa23f1aa-b63e-49ff-1d02-2c661cf8ace4"
                }
            );
        }
    }
}