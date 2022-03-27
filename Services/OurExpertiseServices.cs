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
    public class OurExpertiseServices
    {
        private readonly OleevDbContext _context;

        public OurExpertiseServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<OurExpertiseLanguage> GetAll(string lang)
        {
            var ourexpertise = _context.OurExpertiseLanguages.Include(x => x.OurExpertise).Where(x => x.LangCode == lang).ToList();

            return ourexpertise;
        }

        public OurExpertise Ccreate(OurExpertise ourexpertise)
        {
            _context.OurExpertises.Add(ourexpertise);
            _context.SaveChanges();

            return ourexpertise;
        }

        public void CreateOurExpertise(int OurExpertiseID, string Title, string Description, string SubTitle, string SubDescription, string LangCode, string SEO, string PhotoURL, string Icon)
        {
            

            OurExpertiseLanguage ourexpertiseLanguage = new()
            {
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                SubDescription = SubDescription,
                LangCode = LangCode,
                SEO = SEO,
                OurExpertiseID = OurExpertiseID,
            };
            _context.OurExpertiseLanguages.Add(ourexpertiseLanguage);

            _context.SaveChanges();

        }

        public List<OurExpertiseLanguage> GetOurExpertiseLanguages(int id)
        {
            return _context.OurExpertiseLanguages.Where(x => x.OurExpertise.ID == id).ToList();
        }

        public OurExpertise GetOurExpertiseById(int id)
        {
            return _context.OurExpertises.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(OurExpertise ourexpertise, int OurExpertiseID, int LangID, string Title, string Description, string SubTitle, string SubDescription, string LangCode, string PhotoURL, string Icon)
        {
            SEO seo = new();

            ourexpertise.PhotoURL = PhotoURL;

            _context.OurExpertises.Update(ourexpertise);

            OurExpertiseLanguage ourexpertiseLanguage = new()
            {
                ID = LangID,
                Title = Title,
                Description = Description,
                SubTitle = SubTitle,
                SubDescription = SubDescription,
                LangCode = LangCode,
                SEO = seo.SeoURL(Title),
                OurExpertiseID = OurExpertiseID,

            };

            var updatedEntity = _context.Entry(ourexpertiseLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
