using Group6_Fashion_Merchandise.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group6_Fashion_Merchandise.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactForm model)
        {
            if (ModelState.IsValid)
            {
                
                TempData["Success"] = "Thank you! Your message has been sent successfully.";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
