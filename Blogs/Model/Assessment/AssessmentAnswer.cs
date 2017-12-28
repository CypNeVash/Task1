using System;
using System.Collections.Generic;

namespace Blogs.Model.Assessment
{
    /// <summary>
    /// Entity class AssessmentAnswer, which contein qustion and answers for qustions 
    /// </summary>
    public class AssessmentAnswer : BaseEntity
    {
        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public AssessmentAnswer(Question question, ICollection<Answer> answers)
        {
            Question = question;
            Answers = answers;
        }
        public AssessmentAnswer() { }
    }
}