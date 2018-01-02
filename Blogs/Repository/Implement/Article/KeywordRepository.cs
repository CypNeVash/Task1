using Blogs.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Blogs.Model.Article;
using System.Linq;

namespace Blogs.Repository.Implement.Article
{
    public class KeywordRepository : DefaultRepository<Keyword>
    {
        public override void Add(Keyword data)
        {
            blogsContext.Keywords.Add(data);
            Save();
        }

        public override IEnumerable<Keyword> Get()
        {
            var keys = blogsContext.Keywords.ToList();

            keys.ForEach(s => blogsContext.Entry(s).Collection(item => item.Articles).Load());

            return keys;
        }

        public override Keyword Get(Guid id)
        {
            var key = blogsContext.Keywords.Where(s=>s.Id==id).FirstOrDefault();

            blogsContext.Entry(key).Collection(item => item.Articles).Load();

            return key;
        }
    }
}
