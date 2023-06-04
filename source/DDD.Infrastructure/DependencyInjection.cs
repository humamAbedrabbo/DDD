using DDD.Application.Data;
using DDD.Domain.Repositories;
using DDD.Infrastructure.Data;
using DDD.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContextPool<ApplicationDbContext>(c => 
            c.UseSqlServer(connectionString));

        services.AddScoped<IDbContext, ApplicationDbContext>();
        
        services.AddScoped<IUnitOfWork, ApplicationDbContext>();

        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    }
}
