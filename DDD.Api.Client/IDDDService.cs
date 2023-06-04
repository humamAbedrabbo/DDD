using DDD.Contracts.Companies;
using Refit;

namespace DDD.Api.Client;

public interface IDDDService
{
    [Get("/company")]
    Task<CompanyResponse> GetCompanyAsync();
}