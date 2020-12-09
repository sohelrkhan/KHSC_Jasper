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
    public class HalfYearResultsController : Controller
    {
        private readonly KHSCDBContext _context;

        public HalfYearResultsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: HalfYearResults
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.HalfYearResult.Include(h => h.Exam).Include(h => h.Student).Include(h => h.Subject).Include(h => h.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: HalfYearResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfYearResult = await _context.HalfYearResult
                .Include(h => h.Exam)
                .Include(h => h.Student)
                .Include(h => h.Subject)
                .Include(h => h.Teacher)
                .SingleOrDefaultAsync(m => m.Hy == id);
            if (halfYearResult == null)
            {
                return NotFound();
            }

            return View(halfYearResult);
        }

        // GET: HalfYearResults/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName");
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: HalfYearResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hy,StudentId,TeacherId,SubjectId,ExamId,Ct1,Sub,Obj,Practical,Attendence")] HalfYearResult halfYearResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(halfYearResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", halfYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", halfYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", halfYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", halfYearResult.TeacherId);
            return View(halfYearResult);
        }

        // GET: HalfYearResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfYearResult = await _context.HalfYearResult.SingleOrDefaultAsync(m => m.Hy == id);
            if (halfYearResult == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", halfYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", halfYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", halfYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", halfYearResult.TeacherId);
            return View(halfYearResult);
        }

        // POST: HalfYearResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hy,StudentId,TeacherId,SubjectId,ExamId,Ct1,Sub,Obj,Practical,Attendence")] HalfYearResult halfYearResult)
        {
            if (id != halfYearResult.Hy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(halfYearResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HalfYearResultExists(halfYearResult.Hy))
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
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", halfYearResult.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", halfYearResult.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", halfYearResult.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", halfYearResult.TeacherId);
            return View(halfYearResult);
        }

        // GET: HalfYearResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halfYearResult = await _context.HalfYearResult
                .Include(h => h.Exam)
                .Include(h => h.Student)
                .Include(h => h.Subject)
                .Include(h => h.Teacher)
                .SingleOrDefaultAsync(m => m.Hy == id);
            if (halfYearResult == null)
            {
                return NotFound();
            }

            return View(halfYearResult);
        }

        // POST: HalfYearResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var halfYearResult = await _context.HalfYearResult.SingleOrDefaultAsync(m => m.Hy == id);
            _context.HalfYearResult.Remove(halfYearResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HalfYearResultExists(int id)
        {
            return _context.HalfYearResult.Any(e => e.Hy == id);
        }
    }
}
