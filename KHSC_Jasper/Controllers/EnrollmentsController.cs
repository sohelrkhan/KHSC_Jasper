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
    public class EnrollmentsController : Controller
    {
        private readonly KHSCDBContext _context;

        public EnrollmentsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.Enrollment.Include(e => e.Class).Include(e => e.Section).Include(e => e.Student).Include(e => e.Subject).Include(e => e.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Class)
                .Include(e => e.Section)
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .SingleOrDefaultAsync(m => m.EtId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName");
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName");
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtId,StudentId,TeacherId,ClassId,SectionId,SubjectId,Year")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", enrollment.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", enrollment.SectionId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", enrollment.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", enrollment.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", enrollment.TeacherId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(m => m.EtId == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", enrollment.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", enrollment.SectionId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", enrollment.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", enrollment.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", enrollment.TeacherId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtId,StudentId,TeacherId,ClassId,SectionId,SubjectId,Year")] Enrollment enrollment)
        {
            if (id != enrollment.EtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EtId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", enrollment.ClassId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", enrollment.SectionId);
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", enrollment.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", enrollment.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", enrollment.TeacherId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Class)
                .Include(e => e.Section)
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .Include(e => e.Teacher)
                .SingleOrDefaultAsync(m => m.EtId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(m => m.EtId == id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.EtId == id);
        }
    }
}
