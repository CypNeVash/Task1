using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Model.Interview
{
    public class Option: BaseEntity
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public Option()
        {
        }
        public Option(string text)
        {
            Text = text;
        }

    }
}
