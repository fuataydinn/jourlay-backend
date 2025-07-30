using Jourlay.Application.Utilities.Errors.Base;

namespace Jourlay.Application.Utilities.Result;

public class Result<TValue> : Result
{
    public Result(TValue value) : base(default)
    {
        Value = value;
    }

    public Result(Error error) : base(error)
    {
    }

    public TValue Value { get; } = default;

    public static implicit operator Result<TValue>(TValue data) => new(data);

    public static implicit operator Result<TValue>(Error error) => new(error);
}
