using DDD.Api.Client;
using DDD.Contracts;
using DDD.WinApp.Features.Companies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Windows;

namespace DDD.WinApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(services);
            })
            .Build();

    }

    private IConfiguration AddConfiguration()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        builder.AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        IConfiguration configuration = AddConfiguration();

        services.AddSingleton(typeof(IConfiguration), configuration);

        

        services.AddSingleton<MainWindow>();
        services.AddTransient<Features.Companies.CompanyDetailsForm>();
        services.AddTransient<Features.Companies.CompanyViewModel>();
        
        services.AddDDD(configuration);
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var mainWindow = _host.Services.GetRequiredService<CompanyDetailsForm>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }
        base.OnExit(e);
    }
}
