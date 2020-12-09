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
    public class TeacherSalariesController : Controller
    {
        private readonly KHSCDBContext _context;

        public TeacherSalariesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: TeacherSalaries
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.TeacherSalary.Include(t => t.Teacher);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: TeacherSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSalary = await _context.TeacherSalary
                .Include(t => t.Teacher)
                .SingleOrDefaultAsync(m => m.TsId == id);
            if (teacherSalary == null)
            {
                return NotFound();
            }

            return View(teacherSalary);
        }

        // GET: TeacherSalaries/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email");
            return View();
        }

        // POST: TeacherSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TsId,TeacherId,MonthName,Amount,Date")] TeacherSalary teacherSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", teacherSalary.TeacherId);
            return View(teacherSalary);
        }

        // GET: TeacherSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSalary = await _context.TeacherSalary.SingleOrDefaultAsync(m => m.TsId == id);
            if (teacherSalary == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", teacherSalary.TeacherId);
            return View(teacherSalary);
        }

        // POST: TeacherSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TsId,TeacherId,MonthName,Amount,Date")] TeacherSalary teacherSalary)
        {
            if (id != teacherSalary.TsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherSalaryExists(teacherSalary.TsId))
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
            ViewData["TeacherId"] = new SelectList(_context.TeacherInfo, "TeacherId", "Email", teacherSalary.TeacherId);
            return View(teacherSalary);
        }

        // GET: TeacherSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherSalary = await _context.TeacherSalary
                .Include(t => t.Teacher)
                .SingleOrDefaultAsync(m => m.TsId == id);
            if (teacherSalary == null)
            {
                return NotFound();
            }

            return View(teacherSalary);
        }

        // POST: TeacherSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherSalary = await _context.TeacherSalary.SingleOrDefaultAsync(m => m.TsId == id);
            _context.TeacherSalary.Remove(teacherSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherSalaryExists(int id)
        {
            return _context.TeacherSalary.Any(e => e.TsId == id);
        }
    }
}
