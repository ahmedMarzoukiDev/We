using System.Collections.Generic;

namespace Domain.entities
{
    public class Question
    {
        public int questionId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int editorId { get; set; }
        public virtual ICollection<Answer> answers { get; set; }
        public int lessonId { get; set; }
        public virtual Lesson lesson { get; set; }
    }
}
