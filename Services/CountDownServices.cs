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
    public class CountDownServices
    {
        private readonly OleevDbContext _context;

        public CountDownServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<CountDownLanguage> GetAll(string lang)
        {

            var countdown = _context.CountDownLanguages.Include(x => x.CountDown).Where(x => x.LangCode == lang).ToList();

            return countdown;
        }
        public CountDown Ccreate(CountDown countdown)
        {
            _context.CountDowns.Add(countdown);
            _context.SaveChanges();

            return countdown;
        }

        public void CreateCountDown(int CountDownID, string Title, string LangCode, string SEO, int Count)
        {
            

            CountDownLanguage countDownLanguage = new()
            {
                CountDownID = CountDownID,
                Title = Title,
                LangCode = LangCode,
                SEO = SEO
                
            };
            _context.CountDownLanguages.Add(countDownLanguage);

            _context.SaveChanges();

        }

        public List<CountDownLanguage> GetCountDownLanguages(int id)
        {
            return _context.CountDownLanguages.Where(x => x.CountDown.ID == id).ToList();
        }

        public CountDown GetCountDownById(int id)
        {
            return _context.CountDowns.FirstOrDefault(x => x.ID == id);
        }

        public void Edit(CountDown countdown, int CountDownID, int LangID, string Title, string LangCode, int Count)
        {
            SEO seo = new();

            countdown.Count = Count;

            _context.CountDowns.Update(countdown);

            CountDownLanguage countdownLanguage = new()
            {
                ID = LangID,
                CountDownID = CountDownID,
                Title = Title,
                LangCode = LangCode,
                SEO = seo.SeoURL(Title)


            };

            var updatedEntity = _context.Entry(countdownLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
