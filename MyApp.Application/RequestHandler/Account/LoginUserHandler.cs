using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyApp.Application.RequestCommand.Account;
using MyApp.Domain.Account;

namespace MyApp.Application.RequestHandler.Account
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, bool>
    {
        private readonly IAuthenticate _authentication;
        public LoginUserHandler(IAuthenticate authentication)
        {
            _authentication = authentication;
        }
        public async Task<bool> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var resultLogin = await _authentication.Authenticate(request.Email, request.Password);
            return resultLogin;
        }
    }
}
