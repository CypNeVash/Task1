using System.Collections.Generic;
using Blogs.Repository.Interface.Article;
using Blogs.Context;
using System.Linq;
using Blogs.Model.Article;
using System;

namespace Blogs.Repository.Implement.Article
{
    /// <summary>
    /// Repository of articles, which communicate with database and give data
    /// </summary>
    public class ArticleRepository : DefaulRepository, IArticleRepository
    {
        /// <summary>
        /// Method to get all articles from database
        /// </summary>
        public IEnumerable<Model.Article.Article> Get()
        {
            List<Model.Article.Article> articles = blogsContext.Articles.ToList();

            articles.ForEach(article => blogsContext.Entry(article).Collection(item => item.Reviews).Load());

            Dispose();

            return articles;
        }

        /// <summary>
        /// Method to get all articles from database by id
        /// </summary>
        public Model.Article.Article Get(Guid id)
        {
            Model.Article.Article article = blogsContext.Articles.ToList().Where(s => s.Id == id).FirstOrDefault();

            blogsContext.Entry(article).Collection(item => item.Reviews).Load();

            Dispose();

            return article;
        }

        /// <summary>
        /// Method to remove article from database by link
        /// </summary>
        public void Remove(Model.Article.Article data)
        {
            blogsContext.Articles.Remove(data);

            Save();

            Dispose();
        }

        /// <summary>
        /// Method to add article to database by link
        /// </summary>
        public void Add(Model.Article.Article data)
        {
            blogsContext.Articles.Add(data);

            Save();

            Dispose();
        }
    }
}
