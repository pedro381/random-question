using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Random.Questions.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Random.Questions.Data;

namespace Project.Random.Questions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Settings _settings;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ApplicationDbContext context,
            IOptions<Settings> settings,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _settings = settings.Value;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var applicationDbContext = _context.Category
                    .Include(q => q.Quizzes)
                    .Where(q => q.Quizzes.Any(x => x.Questions.Any(y => y.Alternatives.Any())))
                    .Select(x=> new Category
                    {
                        IdCategory = x.IdCategory,
                        Name = x.Name,
                        Quizzes = x.Quizzes.Where(y => y.Questions.Any(y => y.Alternatives.Any())).ToList()
                    });

                var userId = _context.Users.First(y => y.UserName == User.Identity.Name).Id;
                var replies = await _context.Quiz
                    .Select(x => new TotalReply
                    {
                        IdQuiz = x.IdQuiz
                    }).ToListAsync();

                foreach (var reply in replies)
                {
                    reply.TotalReplies = await _context.Reply.CountAsync(y => y.Alternative.IsCorrect &&
                                                                              y.Alternative.Question.IdQuiz == reply.IdQuiz &&
                                                                              y.IdIdentityUser == userId);
                    reply.TotalQuestions = await _context.Reply.CountAsync(y =>
                                                                              y.Alternative.Question.IdQuiz == reply.IdQuiz &&
                                                                              y.IdIdentityUser == userId);
                }

                ViewData["replies"] = replies;
                return View(await applicationDbContext.ToListAsync());
            }

            return RedirectToPage("/Account/Login", new { area = "Identity" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Quiz(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            var userId = _context.Users.First(y => y.UserName == User.Identity.Name).Id;

            var replies = await _context.Reply
                .Include(r => r.Alternative)
                .Include(r => r.Alternative.Question)
                .Where(x => x.IdIdentityUser == userId && x.Alternative.Question.IdQuiz == id).ToListAsync();
            ViewData["replies"] = replies;

            if (replies.Any())
            {
                var idAlternatives = replies.Select(x => x.IdAlternative);
                quiz.Questions = await _context.Question
                    .Include(r => r.Alternatives)
                    .Where(x => x.Alternatives.Any(y => idAlternatives.Contains(y.IdAlternative))).ToListAsync();
            }
            else
            {
                var questions = await _context.Question.Where(x => x.IdQuiz == id).ToListAsync();

                if (questions.Count <= quiz.TotalQuestionsToAnswer)
                {
                    quiz.Questions = questions;
                }
                else
                {
                    quiz.Questions = new List<Question>();
                    var listNumbers = new List<int>();
                    var rd = new System.Random();
                    int num;
                    for (int i = 0; i < quiz.TotalQuestionsToAnswer; i++)
                    {
                        do
                        {
                            num = rd.Next(0, questions.Count);
                        } while (listNumbers.Contains(num));

                        listNumbers.Add(num);
                        quiz.Questions.Add(questions[num]);
                    }
                }
            }

            foreach (var quizQuestion in quiz.Questions)
            {
                quizQuestion.Alternatives = await _context.Alternative
                    .Where(x => x.IdQuestion == quizQuestion.IdQuestion).ToListAsync();
            }

            return View(quiz);
        }
    }
}
