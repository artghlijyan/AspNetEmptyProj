using AspNetLesson.DbRepo;
using AspNetLesson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetLesson.Controllers
{
    public class HomeController : Controller
    {
        private MobileContext db;

        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); 
            }

            ViewBag.PhoneId = id;

            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Thank you, " + order.User + ", for your order!";
        }
    }
}
