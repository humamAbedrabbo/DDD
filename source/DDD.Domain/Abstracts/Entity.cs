namespace DDD.Domain.Abstracts;

public abstract class Entity<TKey>
    where TKey : notnull, IEquatable<TKey>
{
    public TKey Id { get; protected set; } = default!;
}
