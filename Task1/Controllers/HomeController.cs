using System;
using System.Linq;
using System.Web.Mvc;
using Blogs.Repository.Implement.Article;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Repository.Implement.Assessment;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        ///     Default pages
        ///</summary>
        public ActionResult Index()
        {
            return View(new ArticleRepository().Get());
        }

        /// <summary>
        ///     Page for survey
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Worksheet()
        {
            Survey survey = new SurveyRepository().Get().First();

            if (Request.HttpMethod == "POST")
            {
                Assessment ass = new Assessment(survey, new UserRepository().Get().FirstOrDefault());

                var iter = ass.Survey.Questions.GetEnumerator();

                while (iter.MoveNext())
                {
                    var type = Request.Form[iter.Current.Id.ToString()];

                    ass.Answers.Add(new AssessmentAnswer(iter.Current, type.Split(',').Select(s => new Answer(s)).ToList()));
                }

                new AssessmentRepository().Add(ass);

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

            using (ArticleRepository articleRepository = new ArticleRepository())
            {

                string[] strs = Request.FilePath.Split('/');

                Guid id = new Guid(strs[strs.Length - 1]);

                article = articleRepository.Get(id);

                if (Request.HttpMethod == "POST")
                {
                    if (ModelState.IsValid)
                    {
                        article.Reviews.Add(new Review(review));
                        articleRepository.Save();
                    }
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
                    new ArticleRepository().Add(new Article(article));
            }

            return View();
        }
    }
}