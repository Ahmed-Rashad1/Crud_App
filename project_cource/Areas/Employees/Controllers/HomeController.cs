using Microsoft.AspNetCore.Mvc;

namespace project_cource.Areas.Employees.Controllers
{
    public class HomeController : Controller
    {
        [Area("Employees")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
