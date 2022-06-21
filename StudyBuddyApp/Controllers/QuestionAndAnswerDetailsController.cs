using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddyApp.Data;
using StudyBuddyApp.Models;

namespace StudyBuddyApp.Controllers
{
    // JAKE - This code is an auto-generated starting point for your endpoints.  A lot of this we won't need. Still, I left it for your reference if needed.
    // I only modified the first endpoint "GetQAList" to make sure our controllers display in Swagger.  It could use some more TLC.
    // Have fun!
    public class QuestionAndAnswerDetailsController : Controller
    {
        private readonly StudyBuddyDbContext _context;

        public QuestionAndAnswerDetailsController(StudyBuddyDbContext context)
        {
            _context = context;
        }

        // GET: QuestionAndAnswerDetails
        [HttpGet("GetQAList")]
        public async Task<ActionResult<IEnumerable<QuestionAndAnswerDetail>>> GetQAList()
        {
            if (_context.QuestionAndAnswerDetails == null)
            {
                return NotFound();
            }

            return await _context.QuestionAndAnswerDetails.ToListAsync();
        }

        // GET: QuestionAndAnswerDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuestionAndAnswerDetails == null)
            {
                return NotFound();
            }

            var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails
                .FirstOrDefaultAsync(m => m.Qaid == id);
            if (questionAndAnswerDetail == null)
            {
                return NotFound();
            }

            return View(questionAndAnswerDetail);
        }

        // GET: QuestionAndAnswerDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionAndAnswerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Qaid,Qacategory,Question,Answer")] QuestionAndAnswerDetail questionAndAnswerDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionAndAnswerDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionAndAnswerDetail);
        }

        // GET: QuestionAndAnswerDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuestionAndAnswerDetails == null)
            {
                return NotFound();
            }

            var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails.FindAsync(id);
            if (questionAndAnswerDetail == null)
            {
                return NotFound();
            }
            return View(questionAndAnswerDetail);
        }

        // POST: QuestionAndAnswerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Qaid,Qacategory,Question,Answer")] QuestionAndAnswerDetail questionAndAnswerDetail)
        {
            if (id != questionAndAnswerDetail.Qaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionAndAnswerDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionAndAnswerDetailExists(questionAndAnswerDetail.Qaid))
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
            return View(questionAndAnswerDetail);
        }

        // GET: QuestionAndAnswerDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuestionAndAnswerDetails == null)
            {
                return NotFound();
            }

            var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails
                .FirstOrDefaultAsync(m => m.Qaid == id);
            if (questionAndAnswerDetail == null)
            {
                return NotFound();
            }

            return View(questionAndAnswerDetail);
        }

        // Maybe consider a soft-delete where the IsActive property is set to false
        // POST: QuestionAndAnswerDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuestionAndAnswerDetails == null)
            {
                return Problem("Entity set 'StudyBuddyDbContext.QuestionAndAnswerDetails'  is null.");
            }
            var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails.FindAsync(id);
            if (questionAndAnswerDetail != null)
            {
                _context.QuestionAndAnswerDetails.Remove(questionAndAnswerDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionAndAnswerDetailExists(int id)
        {
          return (_context.QuestionAndAnswerDetails?.Any(e => e.Qaid == id)).GetValueOrDefault();
        }
    }
}
