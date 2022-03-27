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
    public class OurTestimonialController : Controller
    {
        private readonly OurTestimonialServices _services;
        private IWebHostEnvironment _environment;

        public OurTestimonialController(OurTestimonialServices services, IWebHostEnvironment environment)
        {
            _environment = environment;
            _services = services;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            var ourtestimonial = _services.GetAll(langCode);
            if (ourtestimonial.Count > 1)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }

            return View(ourtestimonial);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var langCode = Request.Cookies["Language"];
            var ourtestimonial = _services.GetAll(langCode);
            if (ourtestimonial.Count > 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(OurTestimonial ourtestimonial, List<string> Title, List<string> Description, List<string> Name, List<string> Profession, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            


            _services.Ccreate(ourtestimonial);
            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateOurTestimonial(ourtestimonial.ID, Title[i], Description[i], Name[i], Profession[i], LangCode[i], SEO[i], PhotoURL);
            }


            return RedirectToAction(nameof(Index));



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                OurTestimonialLanguages = _services.GetOurTestimonialLanguages(id),
                OurTestimonial = _services.GetOurTestimonialById(id)

            };


            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(OurTestimonial ourtestimonial, int OurTestimonialID, List<int> LangID, List<string> Title, List<string> Description, List<string> Name, List<string> Profession, List<string> LangCode, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(ourtestimonial, OurTestimonialID, LangID[i],  Title[i], Description[i], Name[i], Profession[i], LangCode[i], path);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
