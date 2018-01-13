using Blogs.Model.Article;
using Blogs.Repository.Implement;
using Blogs.Repository.Interface;
using System;
using System.Web.Mvc;
using Task1.Models.Exeption;
using Task1.Models.Validation.Article;

namespace Task1.Controllers
{
    [ErrorPathExeptionFilter]
    public class GuestsController : Controller
    {
        private readonly IDefaultRepository<Blogs.Model.Article.Article> _articleRepository = FactoryRepository.GetRepository<Blogs.Model.Article.Article>();
        private readonly IDefaultRepository<Keyword> _keywordRepository = FactoryRepository.GetRepository<Keyword>();

        /// <summary>
        ///     Page for review some article
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(Models.Validation.Article.Review review)
        {
            Blogs.Model.Article.Article article;

            string[] strs = Request.FilePath.Split('/');

            Guid id = new Guid(strs[strs.Length - 1]);

            article = _articleRepository.Get(id);

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    article.Reviews.Add(new Blogs.Model.Article.Review().AddReview(review));
                }
            }

            _articleRepository.Save();

            return View(article);
        }

        /// <summary>
        ///     Page for searches
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search()
        {
            string[] strs = Request.FilePath.Split('/');

            Guid id = new Guid(strs[strs.Length - 1]);

            var keys = _keywordRepository.Get(id);

            return View(keys);
        }
    }
}