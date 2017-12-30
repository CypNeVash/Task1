using Blogs.Repository.Interface;
using Blogs.Repository.Implement.Article;
using Blogs.Repository.Implement.Assessment;
using System;

namespace Blogs.Repository.Implement
{
    public static class FactoryRepository
    {
        static public IDefaultRepository<T> GetRepository<T>() where T: class
        {
            switch (typeof(T).Name)
            {
                case "Article": return (IDefaultRepository<T>) new ArticleRepository();
                case "Assessment": return (IDefaultRepository<T>)new AssessmentRepository();
                case "User": return (IDefaultRepository<T>)new UserRepository();
                case "Survey": return (IDefaultRepository<T>)new SurveyRepository();
            }

            throw new NotImplementedException();
        }
    }
}
