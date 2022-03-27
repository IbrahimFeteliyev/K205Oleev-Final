using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OleevDbContext : IdentityDbContext<K205User>
    {
        public OleevDbContext(DbContextOptions<OleevDbContext> options)
           : base(options)
        {
                
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutLanguage> AboutLanguages { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<InfoLanguage> InfoLanguages { get; set; }
        public DbSet<CountDown> CountDowns { get; set; }
        public DbSet<CountDownLanguage> CountDownLanguages { get; set; }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<OurServiceLanguage> OurServiceLanguages { get; set; }
        public DbSet<CaseStudy> CaseStudies { get; set; }
        public DbSet<CaseStudyLanguage> CaseStudyLanguages { get; set; }
        public DbSet<OurTestimonial> OurTestimonials { get; set; }
        public DbSet<OurTestimonialLanguage> OurTestimonialLanguages { get; set; }
        public DbSet<OurExpertise> OurExpertises { get; set; }
        public DbSet<OurExpertiseLanguage> OurExpertiseLanguages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleLanguage> ArticleLanguages { get; set; }
        public DbSet<K205User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<K205User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
        

    }
}
