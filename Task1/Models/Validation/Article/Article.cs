using System;
using Blogs;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Blogs.Model.Article;

namespace Task1.Models.Validation.Article
{
    public class Article
    {
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Author { get; set; }
        [Required]
        [StringLength(1024, MinimumLength = 3)]
        public string Text { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Description { get; set; }

        public ICollection<Keyword> Keywords { get; set; } = new List<Keyword>();
    }

    public static class ExtensionArticle
    {
        public static Blogs.Model.Article.Article AddArticle (this Blogs.Model.Article.Article _article, Article article)
        {
            _article.Title = article.Title;
            _article.Author = article.Author;
            _article.Text = article.Text;
            _article.Description = article.Description;
            _article.Keywords = article.Keywords;

            return _article;
        }
    }
}
