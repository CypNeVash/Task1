using Blogs.Repository.Interface;
using Blogs.Repository.Implement.Article;
using Blogs.Repository.Implement.Assessment;
using Blogs.Repository.Implement.Interview;
using System;

namespace Blogs.Repository.Implement
{
    public static class FactoryRepository
    {
        static public IDefaultRepository<T> GetRepository<T>() where T: new ()
        {
            object temp = new T();

            switch (temp)
            {
                case Model.Article.Article article: return (IDefaultRepository<T>) new ArticleRepository();
                case Model.Assessment.Assessment assessment: return (IDefaultRepository<T>)new AssessmentRepository();
                case Model.Assessment.User user: return (IDefaultRepository<T>)new UserRepository();
                case Model.Assessment.Survey survey: return (IDefaultRepository<T>)new SurveyRepository();
                case Model.Interview.Interview interview: return (IDefaultRepository<T>)new InterviewRepository();
                case Model.Article.Keyword keyword: return (IDefaultRepository<T>)new KeywordRepository();
            }

            throw new NotImplementedException();
        }
    }
}
