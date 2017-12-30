using System;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.Repository.Implement.Interview
{
    public class InterviewRepository : DefaultRepository<Model.Interview.Interview>
    {
        public override void Add(Model.Interview.Interview data)
        {
            throw new NotImplementedException();
        }

        public void AddAnswer(Guid interview, Guid option)
        {
            var select = Get(interview).Options.Where(opt => opt.Id == option).FirstOrDefault();

            select.Count += 1;

            Save();
        }

        public override IEnumerable<Model.Interview.Interview> Get()
        {
            var interviews = blogsContext.Interviews.ToList();

            interviews.ForEach(s => blogsContext.Entry(s).Collection(item => item.Options).Load());

            return interviews;
        }

        public override Model.Interview.Interview Get(Guid id)
        {
            var interview = blogsContext.Interviews.Where(s=>s.Id==id).ToList().FirstOrDefault();

            blogsContext.Entry(interview).Collection(item => item.Options).Load();

            return interview;
        }
    }
}
