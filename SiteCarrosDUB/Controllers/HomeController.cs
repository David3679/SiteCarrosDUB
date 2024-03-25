using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;
using SiteCarrosDUB.Models;
using System.Diagnostics;

namespace SiteCarrosDUB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
