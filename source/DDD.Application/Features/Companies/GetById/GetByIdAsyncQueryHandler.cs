using DDD.Contracts.Companies;
using DDD.Domain.Errors;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositories;
using MediatR;

namespace DDD.Application.Features.Companies.GetById;

internal sealed class GetByIdAsyncQueryHandler
    : IRequestHandler<GetByIdAsyncQuery, CompanyResponse>
{
    private readonly ICompanyRepository _companyRepository;

    public GetByIdAsyncQueryHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<CompanyResponse> Handle(GetByIdAsyncQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository
            .GetByIdAsync(request.Id, cancellationToken) 
            ?? throw new DomainException(DomainErrors.Company.NotFound);
        
        return new CompanyResponse
        {
            Id = company!.Id.Value,
            Name = company.Name,
        };
    }
}
