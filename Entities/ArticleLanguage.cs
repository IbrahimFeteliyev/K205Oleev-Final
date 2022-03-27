using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ArticleLanguage : Base
    {
        public string Title { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoDescription { get; set; }
        public string LangCode { get; set; }
        public string SEO { get; set; }
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
    }
}
