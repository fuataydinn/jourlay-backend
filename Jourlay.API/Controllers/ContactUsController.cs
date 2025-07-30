using Jourlay.API.Controllers.Base;
using Jourlay.Application.Features.ContactUs.Commands.Add;
using Jourlay.Application.Features.ContactUs.Queries;
using Jourlay.Domain.Common.Mediatr;
using Microsoft.AspNetCore.Mvc;

namespace Jourlay.API.Controllers;

public class ContactUsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ContactUsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ContactUsAddCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return Ok(new { success = true, data = result.Value });
        }

        return BadRequest(new { success = false, message = result.Error });
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _mediator.Send(new ContactUsGetQuery());
        if (result.IsSuccess)
        {
            return Ok(new { success = true, data = result.Value });
        }
        return BadRequest(new { success = false, message = result.Error });
    }
}
