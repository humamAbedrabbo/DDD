using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDD.Application.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() 
        where TEntity : class;
}
