using Entities;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    //[Authorize]
    public class InfoController : Controller
    {
        private readonly InfoServices _services;
        private IWebHostEnvironment _environment;


        public InfoController(InfoServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var info = _services.GetAll(langCode);
            if (info.Count > 2)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(info);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var info = _services.GetAll(langCode);
            if (info.Count > 2)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Info info,List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
        {

            _services.Ccreate(info);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateInfo(info.ID, Title[i], Description[i], LangCode[i], SEO[i], PhotoURL);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                InfoLanguages = _services.GetInfoLanguages(id),
                Info = _services.GetInfoById(id)

            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Info info, int InfoID, List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(info, InfoID, LangID[i], Title[i], Description[i], LangCode[i], path);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
