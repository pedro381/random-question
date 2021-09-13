using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Random.Questions.Models
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }
        [Description]
        [MaxLength(1000)]
        public string Description { get; set; }
        [ForeignKey("Quiz")]
        [Display(Name = "Quiz")]
        public int IdQuiz { get; set; }
        public Quiz Quiz { get; set; }
        public List<Alternative> Alternatives { get; set; }
    }
}
