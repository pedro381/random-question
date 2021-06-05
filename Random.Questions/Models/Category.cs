using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project.Random.Questions.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Description]
        public string Name { get; set; }
        public List<Quiz> Quizzes { get; set; }
    }
}
