using System;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.Repository.Implement.Assessment
{
    /// <summary>
    /// Repository of Assessment, which communicate with database and give data
    /// </summary>
    public class AssessmentRepository : DefaulRepository<Model.Assessment.Assessment>
    {
        /// <summary>
        /// Method to get all Assessment from database
        /// </summary>
        public override IEnumerable<Model.Assessment.Assessment> Get()
        {
            List<Model.Assessment.Assessment> assessments = blogsContext.Assessments.ToList();
            assessments.ForEach(
                assessment =>
                {
                    blogsContext.Entry(assessment).Collection(item => item.Answers).Load();

                    blogsContext.Entry(assessment).Reference(item => item.Survey).Load();
                    blogsContext.Entry(assessment).Reference(item => item.User).Load();

                    assessment.Answers.ToList().ForEach(
                        item =>
                        {
                            blogsContext.Entry(item).Collection(value => value.Answers).Load();
                            blogsContext.Entry(item).Reference(value => value.Question).Load();
                        });
                });

            return assessments;
        }

        /// <summary>
        /// Method to get all Assessments from database by id
        /// </summary>
        public override Model.Assessment.Assessment Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to add Assessment to database by link
        /// </summary>
        public override void Add(Model.Assessment.Assessment data)
        {
            blogsContext.Entry(data.Survey).State = System.Data.Entity.EntityState.Modified;
            blogsContext.Entry(data.User).State = System.Data.Entity.EntityState.Modified;

            blogsContext.Assessments.Add(data);

            Save();
        }

    }
}
