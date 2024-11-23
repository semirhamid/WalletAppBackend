using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Application.Features.WalletUser.Queries;

namespace WalletApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{


    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _mediator.Send(new GetWalletUsersQuery());
        return Ok(users);
    }
}
