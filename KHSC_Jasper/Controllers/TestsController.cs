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
    public class TestsController : Controller
    {
        private readonly KHSCDBContext _context;

        public TestsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.Test.Include(t => t.Exam).Include(t => t.Student).Include(t => t.Subject).Include(t => t.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .Include(t => t.Exam)
                .Include(t => t.Student)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .SingleOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName");
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestId,StudentId,TeacherId,SubjectId,ExamId,Sub,Obj,Practical,Attendance")] Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", test.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", test.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", test.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", test.TeacherId);
            return View(test);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test.SingleOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", test.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", test.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", test.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", test.TeacherId);
            return View(test);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestId,StudentId,TeacherId,SubjectId,ExamId,Sub,Obj,Practical,Attendance")] Test test)
        {
            if (id != test.TestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.TestId))
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
            ViewData["ExamId"] = new SelectList(_context.ExamInfo, "ExamId", "ExamName", test.ExamId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", test.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", test.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", test.TeacherId);
            return View(test);
        }

        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Test
                .Include(t => t.Exam)
                .Include(t => t.Student)
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .SingleOrDefaultAsync(m => m.TestId == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var test = await _context.Test.SingleOrDefaultAsync(m => m.TestId == id);
            _context.Test.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(int id)
        {
            return _context.Test.Any(e => e.TestId == id);
        }
    }
}
