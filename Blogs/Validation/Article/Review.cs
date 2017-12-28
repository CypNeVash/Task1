using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blogs.Validation.Article
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
}
