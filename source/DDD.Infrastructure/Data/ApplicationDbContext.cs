using DDD.Application.Data;
using DDD.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext
    ,IUnitOfWork
    ,IDbContext
{
    private ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
