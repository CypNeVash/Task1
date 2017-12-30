using System;
using System.Collections.Generic;
using Blogs.Model.Assessment;

namespace Blogs.Repository.Implement.Assessment
{
    public class UserRepository : DefaultRepository<User>
    {
        /// <summary>
        /// Method to add User to database by link
        /// </summary>
        public override void Add(User data)
        {
            blogsContext.Users.Add(data);

            Save();
        }

        /// <summary>
        /// Method to get all Users from database
        /// </summary>
        public override IEnumerable<User> Get()
        {
            return blogsContext.Users;
        }

        /// <summary>
        /// Method to get all User from database by id
        /// </summary>
        public override User Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
