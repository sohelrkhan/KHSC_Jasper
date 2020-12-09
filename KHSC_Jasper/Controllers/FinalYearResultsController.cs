using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KHSC_Jasper.Models;
using KHSC_Jasper.Filters;

namespace KHSC_Jasper.Controllers
{
    [AttachViewData]
    public class FinalYearResultsController : Controller
    {
        private readonly KHSCDBContext _context;

        public FinalYearResultsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: FinalYearResults
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.FinalYearResult.Include(f => f.Exam).Include(f => f.Student).Include(f => f.Subject).Include(f => f.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: FinalYearResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalYearResult = await _context.FinalYearResult
                .Include(f => f.Exam)
                .Include(f => f.Student)
                .Include(f => f.Subject)
                .Include(f => f.Teacher)
                .SingleOrDefaultAsync(m => m.Fy == id);
            if (finalYearResult == null)
            {
                return NotFound();
            }

            return View(finalYearResult);
        }

        // GET: FinalYearResults/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName");
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: FinalYearResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fy,StudentId,TeacherId,SubjectId,ExamId,Ct2,Sub,Obj,Practical,Attendance")] FinalYearResult finalYearResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finalYearResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", finalYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", finalYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", finalYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", finalYearResult.TeacherId);
            return View(finalYearResult);
        }

        // GET: FinalYearResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalYearResult = await _context.FinalYearResult.SingleOrDefaultAsync(m => m.Fy == id);
            if (finalYearResult == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", finalYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", finalYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", finalYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", finalYearResult.TeacherId);
            return View(finalYearResult);
        }

        // POST: FinalYearResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fy,StudentId,TeacherId,SubjectId,ExamId,Ct2,Sub,Obj,Practical,Attendance")] FinalYearResult finalYearResult)
        {
            if (id != finalYearResult.Fy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalYearResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalYearResultExists(finalYearResult.Fy))
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
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", finalYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", finalYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", finalYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", finalYearResult.TeacherId);
            return View(finalYearResult);
        }

        // GET: FinalYearResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalYearResult = await _context.FinalYearResult
                .Include(f => f.Exam)
                .Include(f => f.Student)
                .Include(f => f.Subject)
                .Include(f => f.Teacher)
                .SingleOrDefaultAsync(m => m.Fy == id);
            if (finalYearResult == null)
            {
                return NotFound();
            }

            return View(finalYearResult);
        }

        // POST: FinalYearResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalYearResult = await _context.FinalYearResult.SingleOrDefaultAsync(m => m.Fy == id);
            _context.FinalYearResult.Remove(finalYearResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalYearResultExists(int id)
        {
            return _context.FinalYearResult.Any(e => e.Fy == id);
        }
    }
}
