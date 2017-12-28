using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Blogs.Model.Assessment
{
    public enum QuestionsType { text, radio, checkbox }
    /// <summary>
    /// Entity class question
    /// </summary>
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public IList<Answer> Answers { get; set; } = new List<Answer>();
        public QuestionsType Type { get; set; }


        public Question(string text, IList<Answer> answers, QuestionsType type)
        {
            Type = type;
            Text = text;
            Answers = answers;
        }
        public Question() { }
    }
}