using System;
using System.Collections.Generic;

namespace Domain.entities
{
    public class Training
    {
       
        public int trainingId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int estimatedTime { get; set; }
        public DateTime dateAdded { get; set; }
        public int difficultyValue { get; set; }
        public string difficultyDescription { get; set; }
        public int editorId { get; set; }
        public virtual ICollection<Lesson> lessons { get; set; }
        public virtual Category category { get; set; }
        public int categoryI { get; set; }
    }
}
