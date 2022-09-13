using Microsoft.Extensions.DependencyInjection;
using MoveIT.Services.Interfaces;

namespace MoveIT.Services;

public static class ServicesRegistration
{
    public static void ServiceRegister(this IServiceCollection services)
    {
        services.AddScoped<IProposalService, ProposalService>();
        services.AddScoped<ICalculatorService, CalculatorService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}