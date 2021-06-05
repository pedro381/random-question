using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Random.Questions.Data;
using Project.Random.Questions.Models;

namespace Project.Random.Questions.Controllers
{
    public class RepliesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public RepliesController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        // GET: Replies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = 
                _context.Reply
                    .Include(r => r.Alternative.Question.Quiz.Category)
                    .Include(r => r.Alternative.Question.Quiz)
                    .Include(r => r.Alternative.Question)
                    .Include(r => r.Alternative)
                    .Include(r => r.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }
        /*
        // GET: Replies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .Include(r => r.Alternative)
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.IdReply == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // GET: Replies/Create
        public IActionResult Create()
        {
            ViewData["IdAlternative"] = new SelectList(_context.Alternative, "IdAlternative", "Description");
            ViewData["IdIdentityUser"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Replies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReply,Date,IdIdentityUser,IdAlternative")] Reply reply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlternative"] = new SelectList(_context.Alternative, "IdAlternative", "Description", reply.IdAlternative);
            ViewData["IdIdentityUser"] = new SelectList(_context.Users, "Id", "UserName", reply.IdIdentityUser);
            return View(reply);
        }

        // GET: Replies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            ViewData["IdAlternative"] = new SelectList(_context.Alternative, "IdAlternative", "Description", reply.IdAlternative);
            ViewData["IdIdentityUser"] = new SelectList(_context.Users, "Id", "UserName", reply.IdIdentityUser);
            return View(reply);
        }

        // POST: Replies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReply,Date,IdIdentityUser,IdAlternative")] Reply reply)
        {
            if (id != reply.IdReply)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReplyExists(reply.IdReply))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlternative"] = new SelectList(_context.Alternative, "IdAlternative", "Description", reply.IdAlternative);
            ViewData["IdIdentityUser"] = new SelectList(_context.Users, "Id", "UserName", reply.IdIdentityUser);
            return View(reply);
        }

        // GET: Replies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = await _context.Reply
                .Include(r => r.Alternative)
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.IdReply == id);
            if (reply == null)
            {
                return NotFound();
            }

            return View(reply);
        }

        // POST: Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reply = await _context.Reply.FindAsync(id);
            _context.Reply.Remove(reply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReplyExists(int id)
        {
            return _context.Reply.Any(e => e.IdReply == id);
        }*/

        [HttpPost]
        public async Task New(List<int> idsAlternatives)
        {
            var userId = _context.Users.First(y => y.UserName == User.Identity.Name).Id;
            var replies = idsAlternatives.Select(x => new Reply
            {
                IdAlternative = x,
                Date = DateTime.Now,
                IdIdentityUser = userId
            });
            await _context.AddRangeAsync(replies);
            await _context.SaveChangesAsync();
            
            var reply = new TotalReply
            {
                IdQuiz = _context.Reply.Where(x => x.IdAlternative == idsAlternatives.FirstOrDefault()).Select(x => x.Alternative.Question.IdQuiz).First()
            };

            var quizName = _context.Quiz.Find(reply.IdQuiz).Name;

            reply.TotalReplies = await _context.Reply.CountAsync(y =>
                y.Alternative.IsCorrect &&
                y.Alternative.Question.IdQuiz == reply.IdQuiz &&
                y.IdIdentityUser == userId);

            reply.TotalQuestions = await _context.Reply.CountAsync(y =>
                y.Alternative.Question.IdQuiz == reply.IdQuiz &&
                y.IdIdentityUser == userId);

            _emailSender.SendEmailAsync(User.Identity.Name, "Answered Questionnaire",
                $"Questionnaire <a href='{HtmlEncoder.Default.Encode(Url.Action("Quiz", "Home", new { id = reply.IdQuiz }, Url.ActionContext.HttpContext.Request.Scheme))}'>{quizName}</a>. was answered. You hit { reply.TotalReplies} out of { reply.TotalQuestions} questions!");

        }
    }
}
