using Blogs.Model.Article;
using Blogs.Model.Assessment;
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

            _context.Users.Add(new User("Parviz", "Musaiev"));

            _context.Interviews.Add(new Blogs.Model.Interview.Interview("Where you from",
                new List<Blogs.Model.Interview.Option>() {
                    new Model.Interview.Option("Germany"),
                    new Model.Interview.Option("Ukrain"),
                    new Model.Interview.Option("France")
                }));

            _context.SaveChanges();
        }
    }
}
