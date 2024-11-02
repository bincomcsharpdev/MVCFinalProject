using Microsoft.AspNetCore.Mvc;
using MVCFinalProject.Interfaces;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View(new ContactDto());
        }

        [HttpPost]
        public async Task<IActionResult> SendContactEmail(ContactDto model)
        {
            if (ModelState.IsValid)
            {
                var message = new YahyContactMessage
                {
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };

                await _contactService.HandleContactMessageAsync(message);

                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("ContactUs");
            }

            return View("ContactUs", model);
        }
    }
}
