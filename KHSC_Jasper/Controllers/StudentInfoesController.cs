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
    public class StudentInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public StudentInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: StudentInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.StudentInfo.Include(s => s.Class).Include(s => s.Group).Include(s => s.Section).Include(s => s.Shift);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: StudentInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo
                .Include(s => s.Class)
                .Include(s => s.Group)
                .Include(s => s.Section)
                .Include(s => s.Shift)
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // GET: StudentInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName");
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName");
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName");
            ViewData["ShiftId"] = new SelectList(_context.ShiftInfo, "ShiftId", "ShiftName");
            return View();
        }

        // POST: StudentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentRoll,SectionId,ClassId,ShiftId,GroupId,Year")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", studentInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", studentInfo.GroupId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", studentInfo.SectionId);
            ViewData["ShiftId"] = new SelectList(_context.ShiftInfo, "ShiftId", "ShiftName", studentInfo.ShiftId);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo.SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", studentInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", studentInfo.GroupId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", studentInfo.SectionId);
            ViewData["ShiftId"] = new SelectList(_context.ShiftInfo, "ShiftId", "ShiftName", studentInfo.ShiftId);
            return View(studentInfo);
        }

        // POST: StudentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentRoll,SectionId,ClassId,ShiftId,GroupId,Year")] StudentInfo studentInfo)
        {
            if (id != studentInfo.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentInfoExists(studentInfo.StudentId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", studentInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", studentInfo.GroupId);
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", studentInfo.SectionId);
            ViewData["ShiftId"] = new SelectList(_context.ShiftInfo, "ShiftId", "ShiftName", studentInfo.ShiftId);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentInfo = await _context.StudentInfo
                .Include(s => s.Class)
                .Include(s => s.Group)
                .Include(s => s.Section)
                .Include(s => s.Shift)
                .SingleOrDefaultAsync(m => m.StudentId == id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            return View(studentInfo);
        }

        // POST: StudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInfo = await _context.StudentInfo.SingleOrDefaultAsync(m => m.StudentId == id);
            _context.StudentInfo.Remove(studentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfoExists(int id)
        {
            return _context.StudentInfo.Any(e => e.StudentId == id);
        }
    }
}
