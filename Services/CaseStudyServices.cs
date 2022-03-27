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
    public class CaseStudyServices
    {
        private readonly OleevDbContext _context;

        public CaseStudyServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CaseStudyLanguage> GetAll(string lang)
        {
            var caseStudy = _context.CaseStudyLanguages.Include(x => x.CaseStudy).Where(x => x.LangCode == lang).ToList();

            return caseStudy;
        }

        public CaseStudy Ccreate(CaseStudy caseStudy)
        {
            _context.CaseStudies.Add(caseStudy);
            _context.SaveChanges();

            return caseStudy;
        }

        public void CreateCaseStudy(int CaseStudyID, string Title, string PhotoTitle , string LangCode,string SEO, string PhotoURL)
        {    

            CaseStudyLanguage caseStudyLanguage = new()
            {
                Title = Title,
                PhotoTitle = PhotoTitle,
                LangCode = LangCode,
                SEO = SEO,
                CaseStudyID = CaseStudyID
            };
            _context.CaseStudyLanguages.Add(caseStudyLanguage);

            _context.SaveChanges();
        }

        public List<CaseStudyLanguage> GetCaseStudyLanguages(int id)
        {
            return _context.CaseStudyLanguages.Where(x => x.CaseStudy.ID == id).ToList();
        }

        public CaseStudy GetCaseStudyById(int id)
        {
            return _context.CaseStudies.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(CaseStudy caseStudy, int CaseStudyID, int LangID, string Title, string PhotoTitle, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            caseStudy.PhotoURL = PhotoURL;

            _context.CaseStudies.Update(caseStudy);

            CaseStudyLanguage caseStudyLanguage = new()
            {
                ID = LangID,
                Title = Title,
                PhotoTitle = PhotoTitle,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                CaseStudyID = CaseStudyID

            };

            var updatedEntity = _context.Entry(caseStudyLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }



    }
}
