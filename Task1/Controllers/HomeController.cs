using System;
using System.Linq;
using System.Web.Mvc;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Repository.Interface;
using Blogs.Repository.Implement;
using Blogs.Model.Interview;
using Task1.Models.Validation.Article;
using Task1.Models.Exeption;

namespace Task1.Controllers
{
    [ErrorPathExeptionFilter]
    public class HomeController : Controller
    {
        private readonly IDefaultRepository<Blogs.Model.Article.Article> _articleRepository = FactoryRepository.GetRepository<Blogs.Model.Article.Article>();
        private readonly IDefaultRepository<Interview> _interviewRepository = FactoryRepository.GetRepository<Interview>();

        /// <summary>
        ///     Default pages
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(string option)
        {
            var interview = _interviewRepository.Get().FirstOrDefault();
            if (Request.HttpMethod == "POST")
            {
                interview.Options.Where(s => s.Id == new Guid(option)).FirstOrDefault().Count++;
                ViewData["Statistics"] = new Task1.Models.Validation.Interview.Interview(interview);
                _interviewRepository.Save();
            }
            else
            {
                ViewData["Questionnaire"] = interview;
            }

            return View(_articleRepository.Get());
        }
    }
}