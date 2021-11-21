using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sky.Areas.Identity.Data;

namespace Sky.Data
{
    public class SkyDbContext : IdentityDbContext<SkyUser>
    {
        public SkyDbContext(DbContextOptions<SkyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            this.SeedRoles(builder);
            //this.SeedUsers(builder);
            //this.SeedUserRoles(builder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<SkyUser>();
            SkyUser user = new SkyUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Email = "tnvinh99@gmail.com",
                NormalizedEmail = "TNVINH99@GMAIL.COM",
                FullName = "Manager",
                CMND = "206213729",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<SkyUser> passwordHasher = new PasswordHasher<SkyUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123456");

            builder.Entity<SkyUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "7dd0b078-2623-4bbe-97e6-1d624169a9d5", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "7dfce7d0-7166-4fc6-b6fd-af43d2cac2fd" },
                new IdentityRole() { Id = "dbb19eb7-7759-46ac-8a0d-62f5a15b1eee", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "ce0362c6-8a1d-468d-80db-ac81b9fcaca8" },
                new IdentityRole() { Id = "fc79330d-96fa-4663-998c-512e0f2a39ef", Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = "6e15d64c-f154-4d89-baf0-d15aad697184" }
            );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fc79330d-96fa-4663-998c-512e0f2a39ef", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
