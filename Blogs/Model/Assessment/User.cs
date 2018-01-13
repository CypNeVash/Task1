using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Model.Assessment
{
    /// <summary>
    /// Entity class User, contains information about interrogated
    /// </summary>
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public User() { }

    }
}
