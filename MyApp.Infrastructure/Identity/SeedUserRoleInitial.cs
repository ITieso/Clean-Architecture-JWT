using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyApp.Domain.Account;

namespace MyApp.Infrastructure.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void seedUser()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
               
                IdentityResult result = _userManager.CreateAsync(user, "K9g8po42").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser userAdmin = new IdentityUser();
                userAdmin.UserName = "admin@localhost";
                userAdmin.Email = "admin@localhost";
                userAdmin.NormalizedEmail = "ADMIN@LOCALHOST";
                userAdmin.NormalizedUserName = "ADMIN@LOCALHOST";
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
                userAdmin.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(userAdmin, "K9g8po42").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(userAdmin, "Admin").Wait();
            }
        }
        public void seedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

        }
    }
}
