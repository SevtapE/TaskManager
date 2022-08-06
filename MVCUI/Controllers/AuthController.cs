using Business.Abstract;
using Core.Core.Security.Dtos;
using Core.Core.Security.Entities;
using Core.Core.Security.Hashing;
using Core.Core.Security.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVCUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        IAuthService _authService;
      

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Register()
        {
      
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var registered = _authService.Register(userForRegisterDto);
            if (registered == null)
            {
                return RedirectToAction("Login");
            }
            var accessToken = _authService.CreateAccessToken(registered);

            return RedirectToPage("/Home/Index");
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
           var loggedIn= _authService.Login(userForLoginDto);
            if (loggedIn==null)
            {
                return View();
            }
            var accessToken=_authService.CreateAccessToken(loggedIn);
            HttpContext.Session.SetString("username", userForLoginDto.Email);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userForLoginDto.Email)
            };

            var userIdentity=new ClaimsIdentity(claims,"a");
            ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);


           
            return RedirectToAction("Index","Home");

        }
    }
}
