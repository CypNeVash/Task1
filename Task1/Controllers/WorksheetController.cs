using Blogs.Model.Assessment;
using Blogs.Repository.Implement;
using Blogs.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Controllers
{
    public class WorksheetController : Controller
    {
        private readonly IDefaultRepository<Survey> _surveyRepository = FactoryRepository.GetRepository<Survey>();
        private readonly IDefaultRepository<User> _userRepository = FactoryRepository.GetRepository<User>();
        private readonly IDefaultRepository<Assessment> _assessmentRepository = FactoryRepository.GetRepository<Assessment>();

        /// <summary>
        ///     Page for survey
        ///</summary>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index()
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

    }
}