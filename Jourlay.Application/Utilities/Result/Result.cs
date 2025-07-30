using Jourlay.Application.Utilities.Errors.Base;

namespace Jourlay.Application.Utilities.Result;

public class Result(Error? error = null)
{
    public static Result Success()
    {
        return new Result(null);
    }

    public static Result Fail(Error error)
    {
        return error;
    }

    public bool IsSuccess { get; } = error is null;
    public Error? Error { get; } = error != null ? error : null;

    public static implicit operator Result(Error error) => new(error);
}

