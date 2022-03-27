using Entities;

namespace K205Oleev.ViewModels
{
    public class HomeVM
    {
        public List<AboutLanguage> AboutLanguages { get; set; }
        public About About { get; set; }
        public List<InfoLanguage> InfoLanguages { get; set; }
        public InfoLanguage InfoLanguage { get; set; }
        public Info Info { get; set; }
        public List<OurServiceLanguage> OurServiceLanguages { get; set; }
        public OurService OurService { get; set; }
        public List<CountDownLanguage> CountDownLanguages { get; set; }
        public CountDown CountDown { get; set; }
        public List<CaseStudyLanguage> CaseStudyLanguages { get; set; }
        public CaseStudy CaseStudy { get; set; }
        public List<OurTestimonialLanguage> OurTestimonialLanguages { get; set; }
        public OurTestimonial OurTestimonial { get; set; }
        public List<OurExpertiseLanguage> OurExpertiseLanguages { get; set; }
        public OurExpertise OurExpertise { get; set; }
        public Article Article { get; set; }
        public List<ArticleLanguage> ArticleLanguages { get; set; }

    }
}
