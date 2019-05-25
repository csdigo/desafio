using Microsoft.AspNetCore.Mvc;

namespace Muniz.Desafio.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}