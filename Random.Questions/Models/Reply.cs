using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Project.Random.Questions.Models
{
    public class Reply
    {
        [Key]
        public int IdReply { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdIdentityUser { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Alternative")]
        public int IdAlternative { get; set; }
        public Alternative Alternative { get; set; }
        public int? IdQuestionNoReply { get; set; }
    }
}
