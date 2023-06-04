using DDD.Contracts.Companies;
using DDD.Domain.Entities.Companies;
using MediatR;

namespace DDD.Application.Features.Companies.GetById;

public record GetByIdAsyncQuery(CompanyId Id)
    : IRequest<CompanyResponse>;
