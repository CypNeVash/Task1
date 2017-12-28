using Blogs.Repository.Interface.Assessment;
using System;
using System.Collections.Generic;
using System.Text;
using Blogs.Model.Assessment;
using Blogs.Context;

namespace Blogs.Repository.Implement.Assessment
{
    public class UserRepository : DefaulRepository, IUserRepository
    {
        /// <summary>
        /// Method to add User to database by link
        /// </summary>
        public void Add(User data)
        {
            blogsContext.Users.Add(data);

            Save();

            Dispose();
        }

        /// <summary>
        /// Method to get all Users from database
        /// </summary>
        public IEnumerable<User> Get()
        {
            return blogsContext.Users;
        }

        /// <summary>
        /// Method to get all User from database by id
        /// </summary>
        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method to remove User from database by link
        /// </summary>
        public void Remove(User data)
        {
            throw new NotImplementedException();
        }
    }
}
