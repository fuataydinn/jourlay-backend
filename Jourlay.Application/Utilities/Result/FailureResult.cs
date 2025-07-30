using Jourlay.Application.Utilities.Errors.Base;
using Jourlay.Domain.Enums.Errors;

namespace Jourlay.Application.Utilities.Result;

public class FailureResult
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public Error? Error { get; set; } = null;
    public Error[] Errors { get; set; } = null;
    public bool IsSuccess { get; set; } = false;
    public ErrorType ErrorType { get; set; } = ErrorType.WARNING;
}
