using System;
using Blogs;
using System.ComponentModel.DataAnnotations;

namespace Blogs.Validation.Article
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
    }
}
