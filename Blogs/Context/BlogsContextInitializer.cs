using Blogs.Model.Account;
using Blogs.Model.Article;
using Blogs.Model.Assessment;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace Blogs.Context
{
    /// <summary>
    ///     Drop and create database if model changes and
    ///     seed the database.
    ///</summary>
    class BlogsContextInitializer : DropCreateDatabaseIfModelChanges<BlogsContext>
    {
        protected override void Seed(BlogsContext _context)
        {

            string Text = "default";

            _context.Survey.Add(new Survey(Text, new List<Question>() {

                new Question("Where's the egg in an egg roll?"
                , new List<Answer>() { new Answer("Because..")
                    ,new Answer("chicken stole")
                    ,new Answer("no time to explain...run!!") }
                , QuestionsType.radio),

                new Question("Why aren't blue berries blue?"
                , new List<Answer>() { new Answer("Because red")
                    ,new Answer("Because green")
                    ,new Answer("Because blue") }
                , QuestionsType.checkbox),

                new Question("Why is a person who plays the piano called a pianist, but a person who drives a race car not called a racist?"
                , new List<Answer>() { new Answer("Political reason")
                    ,new Answer("negros against")
                    ,new Answer("people against") }
                , QuestionsType.checkbox),

                new Question("How long is a piece of string?"
                , new List<Answer>() { new Answer("15ns")
                    ,new Answer("20s")
                    ,new Answer("500ns") }
                , QuestionsType.radio),

                new Question("Would a fly without wings be called a walk?"
                , new List<Answer>() {}
                , QuestionsType.text),

                new Question("Why is there no 'w' in 'one', but there is a 'w' in 'two' and we don't use it?"
                , new List<Answer>(){}
                , QuestionsType.text)
            }));
            _context.Articles.Add(
                new Model.Article.Article("Dogs", "Parviz","Save Dogs", "Gues let save dogs, don`t buy hotdogs"
                , new List<Keyword>() { new Keyword("Save"), new Keyword("Dogs"), new Keyword("World") })
                );

            _context.AssUsers.Add(new User("Parviz", "Musaiev"));

            _context.Interviews.Add(new Blogs.Model.Interview.Interview("Where you from",
                new List<Blogs.Model.Interview.Option>() {
                    new Model.Interview.Option("Germany"),
                    new Model.Interview.Option("Ukrain"),
                    new Model.Interview.Option("France")
                }));


            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "Admin@nure.ua";
                user.Email = "Admin@nure.ua";
                user.LockoutEnabled = true;

                string userPWD = "Admin29++";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Moder"))
            {
                var role = new IdentityRole();
                role.Name = "Moder";
                roleManager.Create(role);

            }



            _context.SaveChanges();
        }
    }
}
