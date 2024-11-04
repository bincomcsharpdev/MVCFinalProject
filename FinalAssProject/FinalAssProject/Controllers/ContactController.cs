using FinalAssProject.Interfaces;
using FinalAssProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalAssProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;

        public ContactController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContactEmail(EmailDto emailDto)
        {
            await _emailService.SendEmail(emailDto);
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
