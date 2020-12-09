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
    public class PretestsController : Controller
    {
        private readonly KHSCDBContext _context;

        public PretestsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: Pretests
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.Pretest.Include(p => p.Exam).Include(p => p.Student).Include(p => p.Subject).Include(p => p.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: Pretests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pretest = await _context.Pretest
                .Include(p => p.Exam)
                .Include(p => p.Student)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .SingleOrDefaultAsync(m => m.PretesetId == id);
            if (pretest == null)
            {
                return NotFound();
            }

            return View(pretest);
        }

        // GET: Pretests/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName");
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: Pretests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PretesetId,StudentId,TeacherId,SubjectId,ExamId,Sub,Obj,Attendance,Practical")] Pretest pretest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pretest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", pretest.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", pretest.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", pretest.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", pretest.TeacherId);
            return View(pretest);
        }

        // GET: Pretests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pretest = await _context.Pretest.SingleOrDefaultAsync(m => m.PretesetId == id);
            if (pretest == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", pretest.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", pretest.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", pretest.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", pretest.TeacherId);
            return View(pretest);
        }

        // POST: Pretests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PretesetId,StudentId,TeacherId,SubjectId,ExamId,Sub,Obj,Attendance,Practical")] Pretest pretest)
        {
            if (id != pretest.PretesetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pretest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PretestExists(pretest.PretesetId))
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
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", pretest.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", pretest.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", pretest.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", pretest.TeacherId);
            return View(pretest);
        }

        // GET: Pretests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pretest = await _context.Pretest
                .Include(p => p.Exam)
                .Include(p => p.Student)
                .Include(p => p.Subject)
                .Include(p => p.Teacher)
                .SingleOrDefaultAsync(m => m.PretesetId == id);
            if (pretest == null)
            {
                return NotFound();
            }

            return View(pretest);
        }

        // POST: Pretests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pretest = await _context.Pretest.SingleOrDefaultAsync(m => m.PretesetId == id);
            _context.Pretest.Remove(pretest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PretestExists(int id)
        {
            return _context.Pretest.Any(e => e.PretesetId == id);
        }
    }
}
