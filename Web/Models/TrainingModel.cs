using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class TrainingModel
    {
        public int trainingId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int estimatedTime { get; set; }
        public int difficultyValue { get; set; }
        public string difficultyDescription { get; set; }
        public ICollection<LessonModel> lessons { get; set; }

    }
}