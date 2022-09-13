using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoveIT.Data.Entities;
using MoveIT.Data.Persistence;
using MoveIT.Data.Persistence.Repositories;
using MoveIT.Data.Persistence.Repositories.Interfaces;

namespace MoveIT.Data;

public static class DataRegistration
{
    public static void DataRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MoveItDbContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(MoveItDbContext).Assembly.FullName)));

        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<MoveItDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IProposalRepository, ProposalRepository>();
    }

}