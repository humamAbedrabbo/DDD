using DDD.Application.Data;
using DDD.Domain.Abstracts;
using DDD.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Repositories;

internal abstract class GenericRepository<TEntity, TPrimaryKey>
    where TEntity : Entity<TPrimaryKey>
    where TPrimaryKey : notnull, IEquatable<TPrimaryKey>
{
    protected IDbContext DbContext { get; }

    public GenericRepository(IDbContext dbContext) => this.DbContext = dbContext;

    public Task<TEntity?> GetByIdAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
    {
        return DbContext.Set<TEntity>()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync(cancellationToken);
    }


}
