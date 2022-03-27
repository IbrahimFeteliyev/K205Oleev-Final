using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helper.Methods;
using DataAccess;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class OurServiceController : Controller
    {
        private readonly OurServiceServices _services;
        private IWebHostEnvironment _environment;

        public OurServiceController(OurServiceServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var ourservice = _services.GetAll(langCode);
            if (ourservice.Count > 2)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(ourservice);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var ourservice = _services.GetAll(langCode);
            if (ourservice.Count > 2)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(OurService ourservice,List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL, string IconURL)
        {

            _services.Ccreate(ourservice);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurService(ourservice.ID, Title[i], Description[i], LangCode[i], SEO[i], PhotoURL, IconURL);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                OurServiceLanguages = _services.GetOurServiceLanguages(id),
                OurService = _services.GetOurServiceById(id)

            };


            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(OurService ourservice, int OurServiceID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, string IconURL, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }


            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(ourservice, OurServiceID,  Title[i], Description[i], LangID[i], LangCode[i], IconURL, path);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
