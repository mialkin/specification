using CSharpFunctionalExtensions;

namespace Specification.Domain;

public sealed class Error : ValueObject
{
    public string Code { get; }

    public string Message { get; }

    internal Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Code;
    }
}
