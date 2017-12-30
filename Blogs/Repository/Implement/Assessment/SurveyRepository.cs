using System;
using System.Collections.Generic;
using Blogs.Model.Assessment;
using System.Linq;

namespace Blogs.Repository.Implement.Assessment
{
    /// <summary>
    /// Repository of Survey, which communicate with database and give data
    /// </summary>
    public class SurveyRepository : DefaulRepository<Survey>
    {
        /// <summary>
        /// Method to get all Surveys from database
        /// </summary>
        public override IEnumerable<Survey> Get()
        {
            List<Survey> surveys = blogsContext.Survey.ToList();

            surveys.ForEach(
                questions =>
                {
                    blogsContext.Entry(questions).Collection(item => item.Questions).Load();

                    questions.Questions.ToList().ForEach(item => blogsContext.Entry(item).Collection(i => i.Answers).Load());
                }
                );

            return surveys;
        }

        /// <summary>
        /// Method to get all Survey from database by id
        /// </summary>
        public override Survey Get(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method to add Survey to database by link
        /// </summary>
        public override void Add(Survey data)
        {
            blogsContext.Survey.Add(data);

            Save();
        }
    }
}
