using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogs.Model.Assessment
{
    /// <summary>
    /// Entity class survey, where contains questions and select answers
    /// </summary>
    public class Survey : BaseEntity
    {
        public string Name { get; set; }
        public IList<Question> Questions { get; set; } = new List<Question>();

        public Survey(string name, IList<Question> questions)
        {
            Name = name;
            Questions = questions;
        }
        public Survey() { }

        public bool Equals(Survey other) => Id == other.Id;
        public override bool Equals(object obj) => base.Equals((Survey)obj);

        public static bool operator ==(Survey survey1, Survey survey2) => survey1.Equals(survey2);
        public static bool operator !=(Survey survey1, Survey survey2) => !(survey1 == survey2);
    }
}