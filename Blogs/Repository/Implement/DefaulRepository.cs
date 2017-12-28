using Blogs.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Repository.Implement
{
    /// <summary>
    /// abstract repository, which contain base set for repository
    /// </summary>
    public abstract class DefaulRepository : IDisposable
    {
        protected BlogsContext blogsContext = SingletonBologsContext.InstanceBlogsContext();


        protected DefaulRepository()
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
    }
}
