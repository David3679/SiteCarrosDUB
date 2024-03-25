using Microsoft.AspNetCore.Mvc;
using SiteCarrosDUB.Filters;

namespace SiteCarrosDUB.Controllers
{
    public class SessaoRestritaController : Controller
    {
        [SessaoRestrita]
        public IActionResult Index()
        {
            return View();
        }
    }
}
