using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoveIT.Data.Entities;

namespace MoveIT.Data.Persistence.Configurations;

internal static class IdentityConfiguration
{
    private const string AdminEmail = "admin@example.com";
    private const string AdminPassword = "admin123$";

    private const string UserEmail = "john@example.com";
    private const string UserPassword = "john123$";

    internal static void SeedData(this ModelBuilder builder)
    {
        var roles = new List<IdentityRole>
        {
            new() { Name = "Admin" },
            new() { Name = "User" },
        };

        builder.Entity<IdentityRole>().HasData(roles);

        var users = new List<AppUser>
        {
            new ()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail,
                Email = AdminEmail,
                NormalizedEmail = AdminEmail,
                EmailConfirmed = true
            },
            new ()
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = UserEmail,
                NormalizedUserName = UserEmail,
                Email = UserEmail,
                NormalizedEmail = UserEmail,
                EmailConfirmed = true
            },
        };

        builder.Entity<AppUser>().HasData(users);

        var passwordHasher = new PasswordHasher<AppUser>();

        users[0].PasswordHash = passwordHasher.HashPassword(users[0], AdminPassword);
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], UserPassword);

        var userRoles = new List<IdentityUserRole<string>>
        {
            new()
            {
                UserId = users[0].Id,
                RoleId = roles.First(r => r.Name == "Admin").Id,
            },
            new()
            {
                UserId = users[1].Id,
                RoleId = roles.First(r => r.Name == "User").Id,
            }
        };

        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}