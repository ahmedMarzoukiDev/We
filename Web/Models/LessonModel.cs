using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LessonModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public int estimatedTime { get; set; }
        public int trainingId { get; set; }
        public virtual TrainingModel training { get; set; }
        public ICollection<QuestionModel> questions { get; set; }
    }
}