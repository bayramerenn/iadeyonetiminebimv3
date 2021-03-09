using CivilManagement.DataAccess.Abstract;
using CivilManagement.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CivilManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUserDal _user;

        public AccountController(IUserDal user)
        {
            _user = user;
        }

       // [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _user.GetUser(model.IdentitNum, model.Phone);
                if (user.Count > 0)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user[0].FirstLastName),
                    new Claim(ClaimTypes.Role,user[0].WorkPlaceCode),
                    new Claim("StoreDesc",user[0].WorkPlaceDescription)
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(50)
                    };
                    await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                    return RedirectToAction("Index", "Return");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adını veya parolayı hatalı girdiniz.!");
                    return View();
                }
            }

            return View();
        }


        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}