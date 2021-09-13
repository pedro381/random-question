using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Random.Questions.Models
{
    public class Alternative
    {
        [Key]
        public int IdAlternative { get; set; }
        [Description]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Display(Name = "Is Correct")]
        public bool IsCorrect { get; set; }
        [ForeignKey("Question")]
        [Display(Name = "Question")]
        public int IdQuestion { get; set; }
        public Question Question { get; set; }
    }
}
