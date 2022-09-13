using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoveIT.Data.Entities;
using MoveIT.Data.Persistence.Configurations;

namespace MoveIT.Data.Persistence;

public class MoveItDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Proposal> Proposals { get; set; }

    public MoveItDbContext(DbContextOptions<MoveItDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(MoveItDbContext).Assembly);
        builder.SeedData();
        base.OnModelCreating(builder);
    }
}