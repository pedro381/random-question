using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Random.Questions.Models
{
    public class Quiz
    {
        [Key]
        public int IdQuiz { get; set; }
        [Description]
        public string Name { get; set; }
        [Display(Name = "Total Questions To Answer")]
        public int TotalQuestionsToAnswer { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public List<Question> Questions { get; set; }
    }
}
