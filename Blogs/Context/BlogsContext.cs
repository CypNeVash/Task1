using System.Collections.Generic;
using System.Data.Entity;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Blogs.Model.Interview;

namespace Blogs.Context
{
    /// <summary>
    ///     Can be used to query from a database and group together
    ///     changes that will then be written back to the store as a unit.
    ///</summary>
    public class BlogsContext : DbContext
    {
        public BlogsContext()
            : base("name=BlogsContext") => Database.SetInitializer(new BlogsContextInitializer());

        public DbSet<Survey> Survey { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
    }
}