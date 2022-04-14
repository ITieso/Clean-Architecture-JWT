using MediatR;

namespace MyApp.Application.RequestCommand.Account
{
    public class RegisterUserRequest : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
