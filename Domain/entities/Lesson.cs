using System;
using System.Collections.Generic;

namespace Domain.entities
{
    public class Lesson
    {
        public int lessonId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int estimatedTime { get; set; }
        public DateTime dateAdded { get; set; }
        public int editorId { get; set; }
        public virtual ICollection<Question> questions { get; set; }
        public int trainingId { get; set; }
        public virtual Training training { get; set; }
    }
}
