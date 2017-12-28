using System;
using System.Collections.Generic;
using Blogs.Model.Assessment;
using Blogs.Repository.Interface.Assessment;
using Blogs.Context;
using System.Linq;

namespace Blogs.Repository.Implement.Assessment
{
    /// <summary>
    /// Repository of Survey, which communicate with database and give data
    /// </summary>
    public class SurveyRepository : DefaulRepository, ISurveyRepository
    {
        /// <summary>
        /// Method to get all Surveys from database
        /// </summary>
        public IEnumerable<Survey> Get()
        {
            List<Survey> surveys = blogsContext.Survey.ToList();

            surveys.ForEach(
                questions =>
                {
                    blogsContext.Entry(questions).Collection(item => item.Questions).Load();

                    questions.Questions.ToList().ForEach(item => blogsContext.Entry(item).Collection(i => i.Answers).Load());
                }
                );

            Dispose();

            return surveys;
        }

        /// <summary>
        /// Method to get all Survey from database by id
        /// </summary>
        public Survey Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to remove Survey from database by link
        /// </summary>
        public void Remove(Survey data)
        {
            blogsContext.Survey.Remove(data);

            Save();

            Dispose();
        }

        /// <summary>
        /// Method to add Survey to database by link
        /// </summary>
        public void Add(Survey data)
        {
            blogsContext.Survey.Add(data);

            Save();

            Dispose();
        }
    }
}
