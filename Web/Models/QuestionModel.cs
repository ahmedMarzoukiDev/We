﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class QuestionModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public int editorId { get; set; }
        public int lessonId { get; set; }
        public int lessonNumber { get; set; }
        public int questionNumber { get; set; }
        public ICollection<AnswerModel> answers { get; set; }
    }
}