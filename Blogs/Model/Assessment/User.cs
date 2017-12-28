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

        public bool Equals(User other) => Id == other.Id;
        public override bool Equals(object obj) => base.Equals((User)obj);

        public static bool operator ==(User user1, User user2) => user1.Equals(user2);
        public static bool operator !=(User user1, User user2) => !(user1 == user2);

    }
}
