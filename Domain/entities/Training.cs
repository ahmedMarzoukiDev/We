using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.entities
{
    public class Training
    {
       [Key]
        public int trainingId { get; set; }
        [Required(ErrorMessage = "training session title is required")]
        public string title { get; set; }
        [Required(ErrorMessage = "description is required")]
        public string description { get; set; }
        [Required(ErrorMessage = "estimated sesson time is required")]
        public int estimatedTime { get; set; }
        
        public DateTime dateAdded { get; set; }
        [Required(ErrorMessage = "difficulty level is required")]
        public int difficultyValue { get; set; }
        [Required(ErrorMessage ="difficulty description is required")]
        public string difficultyDescription { get; set; }
        public int editorId { get; set; }
        public virtual ICollection<Lesson> lessons { get; set; }
        //public virtual Category category { get; set; }
        //public int categoryId { get; set; }
    }
}
