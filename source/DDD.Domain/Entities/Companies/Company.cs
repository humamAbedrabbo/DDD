using DDD.Domain.Abstracts;

namespace DDD.Domain.Entities.Companies;

public class Company : Entity<CompanyId>
{
    public string Name { get; private set; } = null!;

    private Company()
    {
    }

    private Company(string companyName)
    {
        Name = companyName;
    }

    public void Update(string name)
    {
        Name = name;
    }

    public static Company Create(string companyName) =>
        new(companyName);
}
