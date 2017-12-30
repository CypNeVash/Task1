using System;
using System.Linq;
using System.Web.Mvc;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Repository.Interface;
using Blogs.Repository.Implement;
using Blogs.Model.Interview;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDefaultRepository<Article> _articleRepository = FactoryRepository.GetRepository<Article>();
        private readonly IDefaultRepository<User> _userRepository = FactoryRepository.GetRepository<User>();
        private readonly IDefaultRepository<Assessment> _assessmentRepository = FactoryRepository.GetRepository<Assessment>();
        private readonly IDefaultRepository<Survey> _surveyRepository = FactoryRepository.GetRepository<Survey>();
        private readonly IDefaultRepository<Interview> _interviewRepository = FactoryRepository.GetRepository<Interview>();
        /// <summary>
        ///     Default pages
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index()
        {
            return View(_articleRepository.Get());
        }

        /// <summary>
        ///     Page for survey
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Worksheet()
        {
            Survey survey = _surveyRepository.Get().First();

            if (Request.HttpMethod == "POST")
            {
                User user = _userRepository.Get().FirstOrDefault();

                Assessment ass = new Assessment(survey, user);

                var iter = ass.Survey.Questions.GetEnumerator();

                while (iter.MoveNext())
                {
                    var type = Request.Form[iter.Current.Id.ToString()];
                    AssessmentAnswer assessmentAnswer = new AssessmentAnswer(iter.Current, type.Split(',').Select(s => new Answer(s)).ToList());

                    ass.Answers.Add(assessmentAnswer);
                }

                _assessmentRepository.Add(ass);

                return View("Analyzer", ass.Answers);
            }

            return View(survey);
        }

        /// <summary>
        ///     Page for review some article
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Guests(Blogs.Validation.Article.Review review)
        {
            Article article;

            string[] strs = Request.FilePath.Split('/');

            Guid id = new Guid(strs[strs.Length - 1]);

            article = _articleRepository.Get(id);

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    article.Reviews.Add(new Review(review));
                    _articleRepository.Save();
                }
            }
            return View(article);
        }

        /// <summary>
        ///     Page for add article
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddArticle(Blogs.Validation.Article.Article article)
        {

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                    _articleRepository.Add(new Article(article));
            }

            return View();
        }
    }
}