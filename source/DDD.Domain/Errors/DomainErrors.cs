using DDD.Domain.Common;

namespace DDD.Domain.Errors;

public static class DomainErrors
{
    public static class Company
    {
        public static Error NotFound => 
            new 
            (
                "Company.NotFound", 
                "The company with the given identifier not found"
            );
    }
}
