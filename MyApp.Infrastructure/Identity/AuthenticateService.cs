using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyApp.Domain.Account;

namespace MyApp.Infrastructure.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;

        public AuthenticateService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signManager = signInManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
                throw new ApplicationException("Invalid Credentials");

            return result.Succeeded;
        }


        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
                throw new ApplicationException($"Erro on create a new user { result.Errors}");
           
                await _signManager.SignInAsync(applicationUser, false);
            return result.Succeeded;
        }
        public async Task<bool> Logout()
        {
            await _signManager.SignOutAsync();
            return true;
        }

        public async Task<string> JwtGenerator(string email)
        {
            return string.Empty;
                //var user = await _userManager.FindByEmailAsync(email);
                //return user;
        }
    }
}
