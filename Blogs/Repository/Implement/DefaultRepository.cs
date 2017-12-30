using Blogs.Context;
using System;
using Blogs.Repository.Interface;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Repository.Implement
{
    /// <summary>
    /// abstract repository, which contain base set for repository
    /// </summary>
    public abstract class DefaultRepository<T> : IDisposable, IDefaultRepository<T>
    {
        protected BlogsContext blogsContext = SingletonBologsContext.InstanceBlogsContext();


        protected DefaultRepository()
        {

        }

        /// <summary>
        /// Method for save all changes
        /// </summary>
        public void Save()
        {
            blogsContext.SaveChanges();
        }

        /// <summary>
        /// Method to close connection with database
        /// </summary>
        public void Dispose()
        {
            blogsContext.Database.Connection.Close();
        }


        public void Remove(T data)
        {
            blogsContext.Set(data.GetType()).Remove(data);
        }

        abstract public IEnumerable<T> Get();

        abstract public void Add(T data);

        abstract public T Get(Guid id);
    }
}
