namespace Domain.entities
{
    public class Answer
    {
        public int answerId { get; set; }
        public string description { get; set; }
        public int editorId { get; set; }
        public bool isTrue { get; set; }
        public int questionId { get; set; }
        public virtual Question question { get; set; }
    }
}
