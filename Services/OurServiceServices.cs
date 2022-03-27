using DataAccess;
using Entities;
using Helper.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OurServiceServices
    {
        private readonly OleevDbContext _context;

        public OurServiceServices (OleevDbContext context)
        {
            _context = context;
        }

        public List<OurServiceLanguage> GetAll(string lang)
        {
            var ourservice = _context.OurServiceLanguages.Include(x => x.OurService).Where(x => x.LangCode == lang).ToList();

            return ourservice;
        }
        public OurService Ccreate(OurService ourservice)
        {
            _context.OurServices.Add(ourservice);
            _context.SaveChanges();

            return ourservice;
        }
        public void CreateOurService(int OurServiceID , string Title, string Description,string LangCode,string SEO, string PhotoURL, string IconURL)
        {
            
            OurServiceLanguage OurServiceLanguage = new()
            {
                Title = Title,
                Description = Description,
                LangCode = LangCode,
                SEO = SEO,
                OurServiceID = OurServiceID
            };
            _context.OurServiceLanguages.Add(OurServiceLanguage);

            _context.SaveChanges();

            
        }

        public List<OurServiceLanguage> GetOurServiceLanguages(int id)
        {
            return _context.OurServiceLanguages.Where(x => x.OurService.ID == id).ToList();
        }

        public OurService GetOurServiceById(int id)
        {
            return _context.OurServices.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(OurService ourservice, int OurServiceID, string Title, string Description, int LangID, string LangCode, string PhotoURL, string IconURL)
        {
            SEO seo = new();

            ourservice.PhotoURL = PhotoURL;
            ourservice.IconURL = IconURL;

            _context.OurServices.Update(ourservice);

            OurServiceLanguage ourserviceLanguage = new()
            {
                ID = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                OurServiceID = OurServiceID

            };

            var updatedEntity = _context.Entry(ourserviceLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
