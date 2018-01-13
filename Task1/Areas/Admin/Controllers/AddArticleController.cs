using Blogs.Model.Article;
using Blogs.Repository.Implement;
using Blogs.Repository.Interface;
using System.Linq;
using System.Web.Mvc;
using Task1.Models.Validation.Article;

namespace Task1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AddArticleController : Controller
    {
        private readonly IDefaultRepository<Blogs.Model.Article.Article> _articleRepository = FactoryRepository.GetRepository<Blogs.Model.Article.Article>();
        private readonly IDefaultRepository<Keyword> _keywordRepository = FactoryRepository.GetRepository<Keyword>();

        /// <summary>
        ///     Page for add article
        ///</summary>

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(Task1.Models.Validation.Article.Article article, string tags, string[] ctags)
        {
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    if (tags != string.Empty)
                        foreach (var i in tags.Split(' '))
                            article.Keywords.Add(_keywordRepository.Get().Where(s => s.Text == i).FirstOrDefault() ?? new Keyword(i));

                    if (ctags != null)
                        foreach (var i in ctags)
                            article.Keywords.Add(_keywordRepository.Get().Where(s => s.Text == i).FirstOrDefault() ?? new Keyword(i));

                    _articleRepository.Add(new Blogs.Model.Article.Article().AddArticle(article));
                }
            }

            return View(_keywordRepository.Get().ToList());
        }


    }
}