using Blogs.Repository.Interface;
using Blogs.Repository.Implement.Article;
using Blogs.Repository.Implement.Assessment;
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
            }

            throw new NotImplementedException();
        }
    }
}
