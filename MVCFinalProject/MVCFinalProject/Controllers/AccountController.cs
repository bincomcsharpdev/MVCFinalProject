using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;
using MVCFinalProject.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MVCFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<YahyaUser> _signInManager;

        public AccountController(IUserService userService, SignInManager<YahyaUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            if (!ModelState.IsValid) return View(registrationDto);

            var result = await _userService.RegisterUserAsync(registrationDto);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Registration successful.";
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registrationDto);
        }


        [HttpGet]
        public IActionResult Login() => View();

        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var validUser = await _userService.ValidateUserAsync(loginDto);
            if (!validUser)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginDto);
            }

            var user = await _userService.FindByEmailAsync(loginDto.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                TempData["ErrorMessage"] = "User ID not found.";
                return RedirectToAction("Login", "Account");
            }

            var userId = Guid.Parse(userIdClaim);
            var user = await _userService.GetUserAsync(userId);

            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Index", "Home");
            }

            var model = new UserUpdateDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateDto updateDto)
        {
            if (!ModelState.IsValid) return View(updateDto);

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                TempData["ErrorMessage"] = "User ID not found.";
                return RedirectToAction("Login", "Account");
            }

            var userId = Guid.Parse(userIdClaim);
            await _userService.UpdateUserAsync(userId, updateDto);

            TempData["SuccessMessage"] = "Profile updated successfully.";
            return RedirectToAction("Profile");
        }




    }

}
