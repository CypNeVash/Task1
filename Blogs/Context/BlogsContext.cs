using System.Collections.Generic;
using System.Data.Entity;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Model.Interview;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Blogs.Model.Account;

namespace Blogs.Context
{
    /// <summary>
    ///     Can be used to query from a database and group together
    ///     changes that will then be written back to the store as a unit.
    ///</summary>
    public class BlogsContext : IdentityDbContext<ApplicationUser>
    {
        public BlogsContext()
            : base("name=BlogsContext", throwIfV1Schema: false) => Database.SetInitializer(new BlogsContextInitializer());

        public DbSet<Survey> Survey { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> AssUsers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

    }

}