using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.IOptionsModel;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailSetting _emailSettings;

        public HomeController(ILogger<HomeController> logger, EmailSetting emailSetting)
        {
            _logger = logger;
            _emailSettings = emailSetting;
        }

        public IActionResult Index()
        {
            ViewBag.Email = _emailSettings.Email;
            ViewBag.Frequency = _emailSettings?.Frequency;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
