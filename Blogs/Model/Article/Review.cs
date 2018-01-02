using System;

namespace Blogs.Model.Article
{
    /// <summary>
    /// Entity class review
    /// </summary>
    public class Review : BaseEntity
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;

        public Review() { }

        public Review(string author, string text)
        {
            Author = author;
            Text = text;
        }
    }
}