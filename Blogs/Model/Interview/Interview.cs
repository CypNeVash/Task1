using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Model.Interview
{
    public class Interview : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Option> Options { get; set; } = new List<Option>();

        public Interview()
        {
        }

        public Interview(string title, ICollection<Option> answers)
        {
            Title = title;
            Options = answers;
        }
    }
}
