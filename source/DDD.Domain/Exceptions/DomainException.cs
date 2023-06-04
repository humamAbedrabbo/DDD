using DDD.Domain.Common;

namespace DDD.Domain.Exceptions;

public sealed class DomainException : Exception
{
    public Error Error { get; private set; }

    public DomainException(Error error, Exception? innerException = null)
        : base(error.ToString(), innerException) => Error = error;
}
