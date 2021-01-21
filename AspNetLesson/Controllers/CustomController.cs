using AspNetLesson.Util;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLesson.Controllers
{
    public class CustomController : Controller
    {
        public HtmlResult Action()
        {
            return new HtmlResult("<h2>Custom Controller with custom IActionResult</h2>");
        }
    }
}
