using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task1.Models.Validation.Interview
{
    public class Option
    {
        public string Text { get; set; }
        public int Percent { get; set; }

        public Option()
        {
        }

        public Option(Blogs.Model.Interview.Option option, int percent)
        {
            Percent = percent;
            Text = option.Text;
        }
    }
}