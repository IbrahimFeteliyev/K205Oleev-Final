using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{

    [Area("admin")]
    public class OurExpertiseController : Controller
    {
        private readonly OurExpertiseServices _services;
        private IWebHostEnvironment _environment;

        public OurExpertiseController(OurExpertiseServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var ourexpertise = _services.GetAll(langCode);
            if (ourexpertise.Count > 0)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(ourexpertise);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var ourexpertise = _services.GetAll(langCode);
            if (ourexpertise.Count > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(OurExpertise ourexpertise ,List<string> Title, List<string> Description, List<string> SubTitle, List<string> SubDescription, List<string> LangCode, List<string> SEO, string PhotoURL, string Icon)
        {


            _services.Ccreate(ourexpertise);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurExpertise(ourexpertise.ID,Title[i], Description[i], SubTitle[i], SubDescription[i], LangCode[i], SEO[i], PhotoURL, Icon);
            }


            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                OurExpertiseLanguages = _services.GetOurExpertiseLanguages(id),
                OurExpertise = _services.GetOurExpertiseById(id)

            };


            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OurExpertise ourexpertise, int OurExpertiseID, List<int> LangID, List<string> Title, List<string> Description, List<string> SubTitle, List<string> SubDescription, List<string> LangCode, string Icon, IFormFile Image)
        {


            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(ourexpertise, OurExpertiseID, LangID[i], Title[i], Description[i], SubTitle[i], SubDescription[i], LangCode[i], Icon, path);
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
