﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DDD.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => 
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
