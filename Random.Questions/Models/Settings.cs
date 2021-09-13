using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Project.Random.Questions.Models
{
    public class Settings
    {
        public List<string> EmailsAdmins { get; set; }

        public bool IsAdmin(string email)
        {
            return EmailsAdmins.Any(x => x == email);
        }
    }
}