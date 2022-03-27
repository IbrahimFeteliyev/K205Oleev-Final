using System.Diagnostics;
using Entities;
using K205Oleev.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace K205Oleev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly InfoServices _infoServices;
        private readonly OurServiceServices _ourserviceServices;
        private readonly CountDownServices _countdownServices; 
        private readonly CaseStudyServices _caseStudyServices;
        private readonly OurTestimonialServices _ourtestimonialServices;
        private readonly OurExpertiseServices _ourexpertiseServices;
        public HomeController(ILogger<HomeController> logger, AboutServices aboutServices, InfoServices infoServices, OurServiceServices ourserviceServices, CountDownServices countdownServices, CaseStudyServices caseStudyServices, OurTestimonialServices ourtestimonialServices, OurExpertiseServices ourexpertiseServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _infoServices = infoServices;
            _ourserviceServices = ourserviceServices;
            _countdownServices = countdownServices;
            _caseStudyServices = caseStudyServices;
            _ourtestimonialServices = ourtestimonialServices;
            _ourexpertiseServices = ourexpertiseServices;
        }

        public IActionResult Index()
        {
            var langCode = Request.Cookies["Language"];
            HomeVM homeVM = new()
            {
                AboutLanguages = _aboutServices.GetAll(langCode),
                InfoLanguages = _infoServices.GetAll(langCode),
                OurServiceLanguages = _ourserviceServices.GetAll(langCode),
                InfoLanguage = _infoServices.GetOne(),
                CountDownLanguages = _countdownServices.GetAll(langCode),
                CaseStudyLanguages = _caseStudyServices.GetAll(langCode),
                OurTestimonialLanguages = _ourtestimonialServices.GetAll(langCode),
                OurExpertiseLanguages = _ourexpertiseServices.GetAll(langCode),

            }; 
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}