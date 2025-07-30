using Jourlay.Application.Utilities.Errors.Base;

namespace Jourlay.Application.Utilities.Result;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("A validation problem occured.");

    Error[] Errors { get; }
}
