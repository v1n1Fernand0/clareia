using Clareia.Application.Services;
using Clareia.Domain.Interfaces;
using Clareia.Infrastructure.Persistence;
using Clareia.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clareia.Infrastructure.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ClareiaAppContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));


        services.AddScoped<ITermoService, TermoService>();
        services.AddScoped<ILeituraService, LeituraService>();

        // services.AddScoped<IResumoService, ResumoService>();
        // services.AddScoped<IUserProvider, HttpContextUserProvider>();

        return services;
    }
}
