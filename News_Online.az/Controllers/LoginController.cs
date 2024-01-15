using DataAccess.Context;
using DataAccess.Entity;
using Helpers.CookieCrypto;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace News_Online.az.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext db = new AppDbContext();

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User p)
        {
            try
            {
                var user = Login(p);

                Authenticate(user);

                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            //return View();
        }

        public User Login(User p)
        {
            var res = db.Users
            .Where(x => x.UserName == p.UserName)
             .Include(u => u.Role);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();

                var hash = Crypto.GenerateSHA256Hash(p.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    //var dto = _mapper.Map<User, UserDTO>(res.First());
                    // return dto;
                }
                else
                {
                    throw new Exception("Şifrə yalnışdır!");
                }
            }
            else
            {
                throw new Exception("Hesab mövcud deyil");
            }

            return p;
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Login");
        }

        //Cookie
        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.ID.ToString()),
                new Claim("UserName", user.UserName),
                //new Claim(ClaimTypes.Role, user.RoleName),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie");

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
