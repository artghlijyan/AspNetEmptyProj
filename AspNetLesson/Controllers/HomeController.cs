using AspNetLesson.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLesson.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new User());
        }
    }
}
