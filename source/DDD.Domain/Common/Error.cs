namespace DDD.Domain.Common;

public record Error(string ErrorCode, string ErrorMessage)
{
    public override string ToString() => $"{ErrorCode}: {ErrorMessage}";

    public static Error None { get; private set; } = new Error(string.Empty, string.Empty);
}
