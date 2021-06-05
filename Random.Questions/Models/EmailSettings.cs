using System.ComponentModel.DataAnnotations;

namespace Project.Random.Questions.Models
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string DisplayName { get; set; }
        public string UsernameEmail { get; set; }
        public string UsernamePassword { get; set; }
        public string ToEmail { get; set; }
    }
}
