using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.RequestCommand.Account;
using MyApp.Domain.Account;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {

        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create/user")]
        public async Task<IActionResult> Register(RegisterUserRequest registerRequest)
        {
            await _mediator.Send(registerRequest);
            return Ok($"User {registerRequest.Email} created successfully");
        }


    }
}
