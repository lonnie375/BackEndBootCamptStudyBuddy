using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StudyBuddyApp.Data;
using StudyBuddyApp.Models;

namespace StudyBuddyApp.Controllers
{
    // Why do these attributes throw an error.  Are they even needed?
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAndAnswerDetailsController : ControllerBase
    {
        private readonly StudyBuddyDbContext _context;

        public QuestionAndAnswerDetailsController(StudyBuddyDbContext context)
        {
            _context = context;
        }

        //GET: QuestionAndAnswerDetails
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
        [HttpGet("GetQuestionById")]
        public IActionResult GetAnswer(int id)
        {
            QuestionAndAnswerDetail answer = _context.QuestionAndAnswerDetails.FirstOrDefault(x => x.QAId == id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        // POST: QuestionAndAnswerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("PostFavoriteQuestion")]
        public async Task<IActionResult> AddingFavorite(FavoriteQa favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();

                return Ok(favorite);
            }
            else
            {
                return BadRequest();
            }

        }


        //POST: AddToFavoriteList
        [HttpPost("AddToFavoriteList/{userId},{qaId}")]
        public async Task<ActionResult<IEnumerable<FavoriteQa>>> AddToFavoriteList(int userId, int qaId)
        {
            // What is an API?
            // An API (Application Programming Interface) is a software that allows two applications to communicate with each other.

            var newFavQa = new FavoriteQa()
            {
                UserId = userId,
                QAId = qaId,
                IsActive = true
            };

            _context.FavoriteQAs.Add(newFavQa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //PUT: DeleteQaFromFavoriteList
        [HttpPut("DeleteQaFromFavoriteList/{userId},{qaId}")]
        public async Task<ActionResult<IEnumerable<FavoriteQa>>> DeleteQaFromFavoriteList(int userId, int qaId)
        {
            var target = _context.FavoriteQAs.FirstOrDefault(fav => fav.UserId == userId && fav.QAId == qaId);

            if (target == null)
            {
                return NotFound();
            }

            target.IsActive = false;
            _context.FavoriteQAs.Update(target);

            await _context.SaveChangesAsync();

            return Ok();
            //TODO: consider finding a way to return the updated favorites list.
            //TODO: maybe add try-catch
            //TODO: how can we refactor this method to handle adding a QA to favorites list (would need to change name to something like updateFavoritesList)
        }




        //POST: QuestionAndAnswerDetails/Create
        [HttpPost("CreateNewQA")] // For some reason populats DB with {value}, so route params were removed for now
        public async Task<IActionResult> CreateNewQA(string category, string question, string answer)
        {
            var newQA = new QuestionAndAnswerDetail()
            {
                Qacategory = category,
                Question = question,
                Answer = answer
            };

            _context.Add(newQA);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: QuestionAndAnswerDetails/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // GET: QuestionAndAnswerDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.QuestionAndAnswerDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails.FindAsync(id);
        //    if (questionAndAnswerDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(questionAndAnswerDetail);
        //}

        // POST: QuestionAndAnswerDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("QAId,Qacategory,Question,Answer")] QuestionAndAnswerDetail questionAndAnswerDetail)
        //{
        //    if (id != questionAndAnswerDetail.QAId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(questionAndAnswerDetail);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!QuestionAndAnswerDetailExists(questionAndAnswerDetail.QAId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(questionAndAnswerDetail);
        //}

        // GET: QuestionAndAnswerDetails/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.QuestionAndAnswerDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails
        //        .FirstOrDefaultAsync(m => m.QAId == id);
        //    if (questionAndAnswerDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(questionAndAnswerDetail);
        //}

        // Maybe consider a soft-delete where the IsActive property is set to false (except isActive columne not included in DB creation script)
        // POST: QuestionAndAnswerDetails/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.QuestionAndAnswerDetails == null)
        //    {
        //        return Problem("Entity set 'StudyBuddyDbContext.QuestionAndAnswerDetails'  is null.");
        //    }
        //    var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails.FindAsync(id);
        //    if (questionAndAnswerDetail != null)
        //    {
        //        _context.QuestionAndAnswerDetails.Remove(questionAndAnswerDetail);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool QuestionAndAnswerDetailExists(int id)
        //{
        //  return (_context.QuestionAndAnswerDetails?.Any(e => e.QAId == id)).GetValueOrDefault();
        //}
    }
}