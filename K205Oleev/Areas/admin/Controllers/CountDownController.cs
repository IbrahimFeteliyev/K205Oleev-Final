using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]

    public class CountDownController : Controller
    {
        private readonly CountDownServices _services;
        private IWebHostEnvironment _environment;


        public CountDownController(CountDownServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var countdown = _services.GetAll(langCode);
            if (countdown.Count > 3)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(countdown);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var countdown = _services.GetAll(langCode);
            if (countdown.Count > 3)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(CountDown countdown, List<string> Title, List<string> LangCode, List<string> SEO, int Count)
        {


            _services.Ccreate(countdown);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCountDown(countdown.ID, Title[i], LangCode[i], SEO[i], Count);
            }



            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                CountDownLanguages = _services.GetCountDownLanguages(id),
                CountDown = _services.GetCountDownById(id)

            };


            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountDown countdown, int CountDownID, List<int> LangID, List<string> Title, List<string> LangCode, int Count)
        {

            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(countdown, CountDownID, LangID[i], Title[i], LangCode[i], Count);
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
