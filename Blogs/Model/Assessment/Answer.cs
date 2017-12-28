namespace Blogs.Model.Assessment
{
    /// <summary>
    /// Entity class answer
    /// </summary>
    public class Answer : BaseEntity
    {
        public string Text { get; set; }


        public Answer(string text)
        {
            Text = text;
        }
        public Answer() { }

    }
}