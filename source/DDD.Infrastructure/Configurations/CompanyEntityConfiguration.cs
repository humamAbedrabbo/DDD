using DDD.Domain.Constants;
using DDD.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Configurations;

internal sealed class CompanyEntityConfiguration
    : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion
            (
            v => v.Value,
            v => new CompanyId(v)
            );

        builder
            .Property(p => p.Name)
            .HasMaxLength(Constants.Company.Name_Max_Length)
            .IsRequired();
    }
}
