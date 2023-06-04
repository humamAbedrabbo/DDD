using DDD.Domain.Entities.Companies;

namespace DDD.Domain.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(CompanyId id, CancellationToken cancellationToken = default);
}
