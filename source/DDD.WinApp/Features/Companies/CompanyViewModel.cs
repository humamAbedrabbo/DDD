using CommunityToolkit.Mvvm.ComponentModel;
using DDD.Api.Client;
using DDD.Contracts;
using Refit;
using System.Threading.Tasks;

namespace DDD.WinApp.Features.Companies;

public partial class CompanyViewModel : ObservableObject
{
    private readonly DDDSettings settings;
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name = null!;

    public CompanyViewModel(DDDSettings settings)
    {
        this.settings = settings;
    }

    public async Task Load()
    {
        var api = RestService.For<IDDDService>(settings.ServerUrl);
        var model = await api.GetCompanyAsync() ?? new();
        Id = model.Id;
        Name = model.Name;
    }
}
