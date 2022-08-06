using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Areas.Worker.Controllers
{
    [Area("Worker")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
