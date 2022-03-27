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
    public class OurTestimonialServices
    {
        private readonly OleevDbContext _context;

        public OurTestimonialServices(OleevDbContext context)
        {
            _context = context;
        }


        public List<OurTestimonialLanguage> GetAll(string lang)
        {
            var ourtestimonial = _context.OurTestimonialLanguages.Include(x => x.OurTestimonial).Where(x => x.LangCode == lang).ToList();

            return ourtestimonial;
        }

        public OurTestimonial Ccreate(OurTestimonial ourtestimonial)
        {
            _context.OurTestimonials.Add(ourtestimonial);
            _context.SaveChanges();

            return ourtestimonial;
        }

        public void CreateOurTestimonial(int OurTestimonialID, string Title, string Description, string Name, string Profession, string LangCode, string SEO, string PhotoURL)
        {


            OurTestimonialLanguage OurTestimonialLanguage = new()
            {
                Title = Title,
                Description = Description,
                Name = Name,
                Profession = Profession,
                LangCode = LangCode,
                SEO = SEO,
                OurTestimonialID = OurTestimonialID
            };
            _context.OurTestimonialLanguages.Add(OurTestimonialLanguage);

            _context.SaveChanges();

        }

        public List<OurTestimonialLanguage> GetOurTestimonialLanguages(int id)
        {
            return _context.OurTestimonialLanguages.Where(x => x.OurTestimonial.ID == id).ToList();
        }

        public OurTestimonial GetOurTestimonialById(int id)
        {
            return _context.OurTestimonials.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(OurTestimonial ourtestimonial, int OurTestimonialID, int LangID, string Title, string Description, string Name, string Profession, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            ourtestimonial.PhotoURL = PhotoURL;

            _context.OurTestimonials.Update(ourtestimonial);

            OurTestimonialLanguage ourtestimonialLanguage = new()
            {
                ID = LangID,
                Title = Title,
                Description = Description,
                Name = Name,
                SEO = seo.SeoURL(Title),
                Profession = Profession,
                LangCode = LangCode,
                OurTestimonialID = OurTestimonialID

            };

            var updatedEntity = _context.Entry(ourtestimonialLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
