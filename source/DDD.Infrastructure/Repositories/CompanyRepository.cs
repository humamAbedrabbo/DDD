using DDD.Application.Data;
using DDD.Domain.Entities.Companies;
using DDD.Domain.Repositories;

namespace DDD.Infrastructure.Repositories;

internal sealed class CompanyRepository 
    : GenericRepository<Company, CompanyId>,
    ICompanyRepository
{
    public CompanyRepository(IDbContext dbContext)
        : base(dbContext)
    {
    }
}
