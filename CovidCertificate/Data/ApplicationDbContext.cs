namespace CovidCertificate.Data
{
    using CovidCertificate.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CovidCertificate.Data.Models.School> School { get; set; }
        public DbSet<CovidCertificate.Data.Models.Certificate> Certificate { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityRole>(option =>
            {
                option.HasData(
                    new IdentityRole() { Id="AdminRoleId",Name= "Admin",NormalizedName="ADMIN" }
                    );
                option.HasData(
                    new IdentityRole() { Id = "UserRoleId", Name = "User",NormalizedName="USER" }
                    );
            } );
            builder.Entity<User>(option => {

                option.HasData(new User()
                {
                    Id = "adminId",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null,"admin"),
                    Email = "admin@covid.bg",
                    NormalizedEmail = "admin@covid.bg",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty
                }); ;
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "AdminRoleId",
                UserId = "adminId"
            });
            base.OnModelCreating(builder);
        }


    }
}
