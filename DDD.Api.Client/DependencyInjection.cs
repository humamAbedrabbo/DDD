using DDD.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;
using System.Net.Http.Headers;

namespace DDD.Api.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddDDD(this IServiceCollection services
        ,IConfiguration configuration)
    {
        services.Configure<DDDSettings>(
            configuration.GetRequiredSection("DDDSettings"));
        services.AddSingleton(sp =>
            sp.GetRequiredService<IOptions<DDDSettings>>().Value
        );

        services.AddRefitClient<IDDDService>()
                .ConfigureHttpClient(client =>
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri("https://localhost:44322");

                });
        return services;
    }
}