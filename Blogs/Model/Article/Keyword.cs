using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Model.Article
{
    public class Keyword:BaseEntity
    {
        
        public string Text { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Keyword()
        {
        }

        public Keyword(string text)
        {
            Text = text;
        }
    }
}
