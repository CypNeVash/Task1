using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogs.Model.Assessment
{
    /// <summary>
    /// Entity class Assessment, which conteins User, Survey and answers for qustions 
    /// </summary>
    public class Assessment : BaseEntity
    {
        public User User { get; set; }
        public DateTime FillingTime { get; set; } = DateTime.Now;
        public Survey Survey { get; set; }
        public ICollection<AssessmentAnswer> Answers { get; set; } = new List<AssessmentAnswer>();

        public Assessment(Survey survey, User user)
        {
            User = user;
            Survey = survey;
        }
        public Assessment() { }
    }
}