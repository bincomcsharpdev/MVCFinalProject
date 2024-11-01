using Microsoft.AspNetCore.Mvc;
using ResumeManager.Implementation;
using ResumeManager.Models;

namespace ResumeManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new AccountViewModel
            {
                RegisterRequest = new RegisterRequestDto()  
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(AccountViewModel request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result)
            {
                ModelState.AddModelError("", "Registration failed.");
                return View(request);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new AccountViewModel
            {
                LoginRequest = new LoginRequestDto()  
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel request)
        {
            var token = await _authService.LoginAsync(request);
            if (token == null)
            {
                ModelState.AddModelError("", "Invalid credentials.");
                return View(request);
            }

            HttpContext.Session.SetString("JwtToken", token);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JwtToken");

            return RedirectToAction("Register");
        }
    }
}
