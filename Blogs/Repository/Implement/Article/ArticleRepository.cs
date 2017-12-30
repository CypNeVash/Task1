using System.Collections.Generic;
using System.Linq;
using System;

namespace Blogs.Repository.Implement.Article
{
    /// <summary>
    /// Repository of articles, which communicate with database and give data
    /// </summary>
    public class ArticleRepository : DefaultRepository<Model.Article.Article>
    {
        /// <summary>
        /// Method to get all articles from database
        /// </summary>
        public override IEnumerable<Model.Article.Article> Get()
        {
            List<Model.Article.Article> articles = blogsContext.Articles.ToList();

            articles.ForEach(article => blogsContext.Entry(article).Collection(item => item.Reviews).Load());

            return articles;
        }

        /// <summary>
        /// Method to get all articles from database by id
        /// </summary>
        public override Model.Article.Article Get(Guid id)
        {
            Model.Article.Article article = blogsContext.Articles.ToList().Where(s => s.Id == id).FirstOrDefault();

            blogsContext.Entry(article).Collection(item => item.Reviews).Load();

            return article;
        }


        /// <summary>
        /// Method to add article to database by link
        /// </summary>
        public override void Add(Model.Article.Article data)
        {
            blogsContext.Articles.Add(data);

            Save();
        }
    }
}
