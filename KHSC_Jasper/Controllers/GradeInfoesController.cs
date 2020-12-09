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
    public class GradeInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public GradeInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: GradeInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GradeInfo.ToListAsync());
        }

        // GET: GradeInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeInfo = await _context.GradeInfo
                .SingleOrDefaultAsync(m => m.GradeId == id);
            if (gradeInfo == null)
            {
                return NotFound();
            }

            return View(gradeInfo);
        }

        // GET: GradeInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradeId,Grade")] GradeInfo gradeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradeInfo);
        }

        // GET: GradeInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeInfo = await _context.GradeInfo.SingleOrDefaultAsync(m => m.GradeId == id);
            if (gradeInfo == null)
            {
                return NotFound();
            }
            return View(gradeInfo);
        }

        // POST: GradeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradeId,Grade")] GradeInfo gradeInfo)
        {
            if (id != gradeInfo.GradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeInfoExists(gradeInfo.GradeId))
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
            return View(gradeInfo);
        }

        // GET: GradeInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gradeInfo = await _context.GradeInfo
                .SingleOrDefaultAsync(m => m.GradeId == id);
            if (gradeInfo == null)
            {
                return NotFound();
            }

            return View(gradeInfo);
        }

        // POST: GradeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gradeInfo = await _context.GradeInfo.SingleOrDefaultAsync(m => m.GradeId == id);
            _context.GradeInfo.Remove(gradeInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeInfoExists(int id)
        {
            return _context.GradeInfo.Any(e => e.GradeId == id);
        }
    }
}
