using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Random.Questions.Data;
using Project.Random.Questions.Models;

namespace Project.Random.Questions.Controllers
{
    public class AlternativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlternativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alternatives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alternative.Include(a => a.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alternatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.IdAlternative == id);
            if (alternative == null)
            {
                return NotFound();
            }

            return View(alternative);
        }

        // GET: Alternatives/Create
        public IActionResult Create()
        {
            ViewData["IdQuestion"] = new SelectList(_context.Question, "IdQuestion", "Description");
            return View();
        }

        // POST: Alternatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlternative,Description,IsCorrect,IdQuestion")] Alternative alternative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alternative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdQuestion"] = new SelectList(_context.Question, "IdQuestion", "Description", alternative.IdQuestion);
            return View(alternative);
        }

        // GET: Alternatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative.FindAsync(id);
            if (alternative == null)
            {
                return NotFound();
            }
            ViewData["IdQuestion"] = new SelectList(_context.Question, "IdQuestion", "Description", alternative.IdQuestion);
            return View(alternative);
        }

        // POST: Alternatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlternative,Description,IsCorrect,IdQuestion")] Alternative alternative)
        {
            if (id != alternative.IdAlternative)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alternative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlternativeExists(alternative.IdAlternative))
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
            ViewData["IdQuestion"] = new SelectList(_context.Question, "IdQuestion", "Description", alternative.IdQuestion);
            return View(alternative);
        }

        // GET: Alternatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alternative = await _context.Alternative
                .Include(a => a.Question)
                .FirstOrDefaultAsync(m => m.IdAlternative == id);
            if (alternative == null)
            {
                return NotFound();
            }

            return View(alternative);
        }

        // POST: Alternatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alternative = await _context.Alternative.FindAsync(id);
            _context.Alternative.Remove(alternative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlternativeExists(int id)
        {
            return _context.Alternative.Any(e => e.IdAlternative == id);
        }
    }
}
