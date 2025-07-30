using Jourlay.Application.Utilities.Errors.Base;
using Jourlay.Application.Utilities.Result;
using Microsoft.AspNetCore.Mvc;

namespace Jourlay.API.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    protected IActionResult ApiResponse(Result result)
    {
        return result.IsSuccess ? Ok(result) : BadRequest(HandleFailure(result));
    }

    protected FailureResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),

            IValidationResult validationResult =>
                 CreateFailureResult(
                     title: "Validation Error",
                     errors: validationResult.Errors),
            _ =>
                CreateFailureResult(
                    title: "Bad Request",
                    error: result.Error)
        };
    }

    private static FailureResult CreateFailureResult(string title, Error? error = null, Error[]? errors = null)
        => new()
        {
            Title = title,
            Status = StatusCodes.Status400BadRequest,
            Error = error,
            Errors = errors,
            ErrorType = error.HasValue ? error.Value.ErrorType : errors.First().ErrorType
        };
}
