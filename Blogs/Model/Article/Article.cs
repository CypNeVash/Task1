using System;
using System.Collections.Generic;

namespace Blogs.Model.Article
{
    /// <summary>
    /// Entity сlass article, which contain information about article and all reviews
    /// </summary>
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public string Author { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Keyword> Keywords { get; set; }

        public string Preview { get { return Text.Length > 200 ? Text.Substring(0, 200) : Text; } }

        public Article() { }
        public Article(string title, string author, string description, string text, ICollection<Keyword> keywords)
        {
            Title = title;
            Author = author;
            Text = text;
            Description = description;
            Keywords = keywords;
        }
    }
}