using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyApp.Application.RequestCommand.Account;
using MyApp.Domain.Account;

namespace MyApp.Application.RequestHandler.Account
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, bool>

    {
        private readonly IAuthenticate _authentication;
        public RegisterUserHandler(IAuthenticate authentication)
        {
            _authentication = authentication;
        }
        public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {

            var response = await _authentication.RegisterUser(request.Email, request.Password);
            return response;
        }
    }
}
