using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task1.Models.Validation.Article
{
    public class Review
    {
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string Author { get; set; }
        [Required]
        [StringLength(1024, MinimumLength = 3)]
        public string Text { get; set; }
    }

    public static class ExtensionReview
    {
        public static Blogs.Model.Article.Review AddReview(this Blogs.Model.Article.Review _review, Review review)
        {
            _review.Author = review.Author;
            _review.Text = review.Text;

            return _review;
        }
    }
}
