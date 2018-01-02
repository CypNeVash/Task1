using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task1.Models.Validation.Interview
{
    public class Interview
    {
        public string Title { get; set; }
        public ICollection<Option> Options { get; set; } = new List<Option>();

        public Interview()
        {
        }

        public Interview(Blogs.Model.Interview.Interview interview)
        {
            Title = interview.Title;
            int totalCount = interview.Options.Select(s => s.Count).Sum();
            interview.Options.ToList().ForEach(s => Options.Add(new Option(s, s.Count * 100 /totalCount)));
        }
    }
}