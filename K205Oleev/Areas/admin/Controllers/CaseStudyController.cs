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
    public class CaseStudyController : Controller
    {

        private readonly CaseStudyServices _services;
        private IWebHostEnvironment _environment;

        public CaseStudyController(CaseStudyServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var caseStudy = _services.GetAll(langCode);
            if (caseStudy.Count > 1)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;   
            }


            return View(caseStudy);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var caseStudy = _services.GetAll(langCode);
            if (caseStudy.Count > 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(CaseStudy caseStudy, List<string> Title, List<string> PhotoTitle, List<string> LangCode, List<string> SEO, string PhotoURL)
        {


            _services.Ccreate(caseStudy);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateCaseStudy(caseStudy.ID, Title[i], PhotoTitle[i], LangCode[i], SEO[i], PhotoURL);
            }



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                CaseStudyLanguages = _services.GetCaseStudyLanguages(id),
                CaseStudy = _services.GetCaseStudyById(id)

            };


            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(CaseStudy caseStudy, int CaseStudyID, List<int> LangID, List<string> Title, List<string> PhotoTitle, List<string> LangCode, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(caseStudy, CaseStudyID, LangID[i], Title[i], PhotoTitle[i], LangCode[i], path);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
