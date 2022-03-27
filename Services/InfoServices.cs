using DataAccess;
using Entities;
using Helper.Methods;
using Microsoft.EntityFrameworkCore;


namespace Services
{
    public class InfoServices
    {
        private readonly OleevDbContext _context;

        public InfoServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<InfoLanguage> GetAll(string lang)
        {
            var info = _context.InfoLanguages.Include(x => x.Info).Where(x => x.LangCode == lang && x.Info.IsSlider == true).ToList();

            return info;
        }

        public Info Ccreate(Info info)
        {
            _context.Infos.Add(info);
            _context.SaveChanges();

            return info;
        }
        public InfoLanguage GetOne()
        {

            return _context.InfoLanguages.Include(x => x.Info).Where(x => x.Info.IsHeader == true).FirstOrDefault();
        }

        public void CreateInfo(int InfoID, string Title, string Description, string LangCode, string SEO, string PhotoURL)
        {


            InfoLanguage infoLanguage = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                InfoID = InfoID
            };
            _context.InfoLanguages.Add(infoLanguage);

            _context.SaveChanges();

        }
        public List<InfoLanguage> GetInfoLanguages(int id)
        {
            return _context.InfoLanguages.Where(x => x.Info.ID == id).ToList();
        }

        public Info GetInfoById(int id)
        {
            return _context.Infos.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(Info info, int InfoID, int LangID, string Title, string Description, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            info.PhotoURL = PhotoURL;

            _context.Infos.Update(info);

            InfoLanguage infoLanguage = new()
            {
                ID = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                InfoID = InfoID

            };

            var updatedEntity = _context.Entry(infoLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
