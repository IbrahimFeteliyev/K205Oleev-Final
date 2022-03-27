using Microsoft.AspNetCore.Mvc;

namespace K205Oleev.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index(string lang)
        {
            CookieOptions cookieOptions = new();
            Response.Cookies.Append("Language", lang);

            return RedirectToAction("Index", "Home");


            return View();
        }
    }
}
