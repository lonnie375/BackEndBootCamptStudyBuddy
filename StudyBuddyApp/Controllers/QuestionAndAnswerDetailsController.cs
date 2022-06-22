﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using StudyBuddyApp.Data;
using StudyBuddyApp.Models;

namespace StudyBuddyApp.Controllers
{
    public class QuestionAndAnswerDetailsController : Controller
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

        //GET: QuestionAndAnswerDetailsById
        public async Task<ActionResult<QuestionAndAnswerDetail>> QuestionAndAnswerDetailByQAId(int id)
        {
            if (id == null || _context.QuestionAndAnswerDetails == null)
            {
                return NotFound();
            }

            var questionAndAnswerDetail = await _context.QuestionAndAnswerDetails.FirstOrDefaultAsync(m => m.Qaid == id);
            if (questionAndAnswerDetail == null)
            {
                return NotFound();
            }

            return questionAndAnswerDetail;
        }

        //GET: GetListFavoriteQAByUserId
        [HttpGet("GetListFavoriteQaByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<QuestionAndAnswerDetail>>> GetListFavoriteQaByUserId(int userId)
        {
            var resultList = new List<QuestionAndAnswerDetail>();

            if (userId == null || _context.FavoriteQAs == null)
            {
                return NotFound();
            }

            var favQaIdList = _context.FavoriteQAs.Where(fav => fav.UserId == userId && fav.IsActive == true).Select(qa => qa.Qaid);

            if (favQaIdList == null)
            {
                return NotFound();
            }

            foreach (var qa in _context.QuestionAndAnswerDetails)
            {
                if (favQaIdList.Contains(qa.Qaid))
                {
                    resultList.Add(qa);
                }
            }

            return resultList;
        }

        //PUT: DeleteQaFromFavoriteList
        [HttpPut("DeleteQaFromFavoriteList/{userId},{qaId}")]
        public async Task<ActionResult<IEnumerable<FavoriteQa>>> DeleteQaFromFavoriteList(int userId, int qaId)
        {
            var target = _context.FavoriteQAs.FirstOrDefault(fav => fav.UserId == userId && fav.Qaid == qaId);

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

        //POST: AddToFavoriteList
        [HttpPost(" /{userId},{qaId}")]
        public async Task<ActionResult<IEnumerable<FavoriteQa>>> AddToFavoriteList(int userId, int qaId)
        {
            //var newFavQa = _context.QuestionAndAnswerDetails.FirstOrDefault(qa => qa.Qaid == qaId);

            var newFavQa = new FavoriteQa()
            {
                UserId = userId,
                Qaid = qaId,
                IsActive = true
            };

            _context.FavoriteQAs.Add(newFavQa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: QuestionAndAnswerDetails/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: QuestionAndAnswerDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Qaid,Qacategory,Question,Answer")] QuestionAndAnswerDetail questionAndAnswerDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(questionAndAnswerDetail);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(questionAndAnswerDetail);
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
        //public async Task<IActionResult> Edit(int id, [Bind("Qaid,Qacategory,Question,Answer")] QuestionAndAnswerDetail questionAndAnswerDetail)
        //{
        //    if (id != questionAndAnswerDetail.Qaid)
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
        //            if (!QuestionAndAnswerDetailExists(questionAndAnswerDetail.Qaid))
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
        //        .FirstOrDefaultAsync(m => m.Qaid == id);
        //    if (questionAndAnswerDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(questionAndAnswerDetail);
        //}

        // Maybe consider a soft-delete where the IsActive property is set to false
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
        //  return (_context.QuestionAndAnswerDetails?.Any(e => e.Qaid == id)).GetValueOrDefault();
        //}
    }
}