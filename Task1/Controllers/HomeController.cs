using System;
using System.Linq;
using System.Web.Mvc;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Repository.Interface;
using Blogs.Repository.Implement;
using Blogs.Model.Interview;
using Task1.Models.Validation.Article;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDefaultRepository<Blogs.Model.Article.Article> _articleRepository = FactoryRepository.GetRepository<Blogs.Model.Article.Article>();
        private readonly IDefaultRepository<User> _userRepository = FactoryRepository.GetRepository<User>();
        private readonly IDefaultRepository<Assessment> _assessmentRepository = FactoryRepository.GetRepository<Assessment>();
        private readonly IDefaultRepository<Survey> _surveyRepository = FactoryRepository.GetRepository<Survey>();
        private readonly IDefaultRepository<Keyword> _keywordRepository = FactoryRepository.GetRepository<Keyword>();
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
                ViewData["Statistics"] =new Task1.Models.Validation.Interview.Interview( interview);
            }
            else
            {
                ViewData["Questionnaire"] = interview;
            }
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
        public ActionResult Guests(Models.Validation.Article.Review review)
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
            return View(article);
        }

        /// <summary>
        ///     Page for add article
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddArticle(Task1.Models.Validation.Article.Article article, string tags)
        {
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    foreach (var i in tags.Split(' '))
                        article.Keywords.Add(_keywordRepository.Get().Where(s => s.Text == i).FirstOrDefault() ?? new Keyword(i));
                    _articleRepository.Add(new Blogs.Model.Article.Article().AddArticle(article));
                }
            }

            return View();
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