using AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Models;
using AcademyA_CDO.Week6.Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcademyA_CDO.Week6.ASPNETCoreWebApp_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IMainBusinessLayer bl;

        public UserController(IMainBusinessLayer businessLayer)
        {
            bl = businessLayer;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new UserLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userVm)
        {
            if (userVm == null)
                return View();
            var account = bl.GetAccount(userVm.Username);
            if (account != null && ModelState.IsValid)
            {
                if (account.Password.Equals(userVm.Password))
                {
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, account.Role.ToString())
                    };
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = System.DateTimeOffset.UtcNow.AddHours(1),
                        RedirectUri = userVm.ReturnUrl
                    };

                    var claimIedentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIedentity),
                        properties);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(userVm), "Invalid Password");
                    return View(userVm);
                }
            }
            return View(userVm);
        }
    }
}
