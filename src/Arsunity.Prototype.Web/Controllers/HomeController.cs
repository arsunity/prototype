using Microsoft.AspNetCore.Mvc;

namespace Arsunity.Prototype.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}