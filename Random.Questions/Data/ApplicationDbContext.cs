using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project.Random.Questions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project.Random.Questions.Models.Category> Category { get; set; }
        public DbSet<Project.Random.Questions.Models.Quiz> Quiz { get; set; }
        public DbSet<Project.Random.Questions.Models.Question> Question { get; set; }
        public DbSet<Project.Random.Questions.Models.Alternative> Alternative { get; set; }
        public DbSet<Project.Random.Questions.Models.Reply> Reply { get; set; }
    }
}
