using Ipsum.Infrastructure;
using Ipsum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ipsum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailService _service;

        public HomeController(ILogger<HomeController> logger, EmailService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EmailSender(EmailViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "Email введен неверно.");
            }

            if (ModelState.IsValid)
            {
                _service.SendLetter(model.Email); 
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}