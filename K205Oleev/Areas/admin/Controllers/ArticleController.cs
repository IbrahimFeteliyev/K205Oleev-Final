using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class ArticleController : Controller
    {
        private readonly OleevDbContext _context;
        private IWebHostEnvironment _environment;

        public ArticleController(OleevDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var article = _context.ArticleLanguages.Include(x => x.Article).Where(x => x.LangCode == "AZ").ToList();
            return View(article);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> PhotoTitle, List<string> PhotoDescription, List<string> LangCode, List<string> SEO, string PhotoURL , string Time)
        {
            Article article = new()
            {
                PhotoURL = PhotoURL,
                Time = Time,
                CreatedDate = DateTime.Now
            };

            _context.Articles.Add(article);
            _context.SaveChanges();

            for (int i = 0; i < Title.Count; i++)
            {
                ArticleLanguage articleLanguage = new()
                {
                    Title = Title[i],
                    PhotoTitle = PhotoTitle[i],
                    PhotoDescription = PhotoDescription[i],
                    LangCode = LangCode[i],
                    SEO = SEO[i],
                    ArticleID = article.ID
                };
                _context.ArticleLanguages.Add(articleLanguage);
            }


            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            EditVM editVM = new()
            {
                ArticleLanguages = _context.ArticleLanguages.Include(x => x.Article).Where(x => x.ArticleID == id).ToList(),
                Article = _context.Articles.FirstOrDefault(x => x.ID == id.Value)
            };

            return View(editVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int ArticleID, List<int> LangID, List<string> Title, List<string> PhotoTitle, List<string> PhotoDescription, List<string> LangCode, string PhotoURL)
        {
            for (int i = 0; i < Title.Count; i++)
            {
                SEO seo = new();

                ArticleLanguage ArticleLanguage = new()
                {
                    ID = LangID[i],
                    Title = Title[i],
                    PhotoTitle = PhotoTitle[i],
                    PhotoDescription = PhotoDescription[i],
                    SEO = seo.SeoURL(Title[i]),
                    LangCode = LangCode[i],
                    ArticleID = ArticleID
                };
                var updatedEntity = _context.Entry(ArticleLanguage);
                updatedEntity.State = EntityState.Modified;

            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
