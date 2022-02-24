using CovidCertificate.Data;
using CovidCertificate.Data.Models;
using CovidCertificate.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidCertificate.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,SignInManager<User> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> CreateRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("User"));
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> AddUserToRole()
        {
            User user = await userManager.GetUserAsync(this.User);
            var result = await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new User
            {
                UserName= model.Username,
                Email = model.Email,
                FirstName=model.FirstName,
                MiddleName=model.MiddleName,
                LastName=model.LastName
            };
            var result = this.userManager.CreateAsync(user,model.Password).Result;
            if (result.Succeeded)
            {
                if (this.userManager.Users.Count() == 1)
                {
                    var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "Admin").Result;
                    if (roleResult.Errors.Any())
                    {
                        return this.View();
                    }
                }
                else
                {
                    var roleResult = this.signInManager.UserManager.AddToRoleAsync(user, "User").Result;
                    if (roleResult.Errors.Any())
                    {
                        return this.View();
                    }
                }

                return this.RedirectToAction("Index", "Home");
            }

            this.signInManager.SignInAsync(user, isPersistent: false);
            return this.View();
        }
        public IActionResult Login()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.userManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            var result = this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true).Result;
            if (result.Succeeded)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
