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
    public class TeacherInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public TeacherInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: TeacherInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.TeacherInfo.Include(t => t.Subject);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: TeacherInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo
                .Include(t => t.Subject)
                .SingleOrDefaultAsync(m => m.TeacherId == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }

            return View(teacherInfo);
        }

        // GET: TeacherInfoes/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName");
            return View();
        }

        // POST: TeacherInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,SubjectId,Email,Cell,Position")] TeacherInfo teacherInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", teacherInfo.SubjectId);
            return View(teacherInfo);
        }

        // GET: TeacherInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo.SingleOrDefaultAsync(m => m.TeacherId == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", teacherInfo.SubjectId);
            return View(teacherInfo);
        }

        // POST: TeacherInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,TeacherName,SubjectId,Email,Cell,Position")] TeacherInfo teacherInfo)
        {
            if (id != teacherInfo.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherInfoExists(teacherInfo.TeacherId))
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
            ViewData["SubjectId"] = new SelectList(_context.SubjectInfo, "SubjectId", "SubjectName", teacherInfo.SubjectId);
            return View(teacherInfo);
        }

        // GET: TeacherInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherInfo = await _context.TeacherInfo
                .Include(t => t.Subject)
                .SingleOrDefaultAsync(m => m.TeacherId == id);
            if (teacherInfo == null)
            {
                return NotFound();
            }

            return View(teacherInfo);
        }

        // POST: TeacherInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherInfo = await _context.TeacherInfo.SingleOrDefaultAsync(m => m.TeacherId == id);
            _context.TeacherInfo.Remove(teacherInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherInfoExists(int id)
        {
            return _context.TeacherInfo.Any(e => e.TeacherId == id);
        }
    }
}
