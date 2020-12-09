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
    public class SectionInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public SectionInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: SectionInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.SectionInfo.Include(s => s.Class);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: SectionInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionInfo = await _context.SectionInfo
                .Include(s => s.Class)
                .SingleOrDefaultAsync(m => m.SectionId == id);
            if (sectionInfo == null)
            {
                return NotFound();
            }

            return View(sectionInfo);
        }

        // GET: SectionInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName");
            return View();
        }

        // POST: SectionInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SectionId,SectionName,ClassId")] SectionInfo sectionInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectionInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", sectionInfo.ClassId);
            return View(sectionInfo);
        }

        // GET: SectionInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionInfo = await _context.SectionInfo.SingleOrDefaultAsync(m => m.SectionId == id);
            if (sectionInfo == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", sectionInfo.ClassId);
            return View(sectionInfo);
        }

        // POST: SectionInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SectionId,SectionName,ClassId")] SectionInfo sectionInfo)
        {
            if (id != sectionInfo.SectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectionInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionInfoExists(sectionInfo.SectionId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", sectionInfo.ClassId);
            return View(sectionInfo);
        }

        // GET: SectionInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectionInfo = await _context.SectionInfo
                .Include(s => s.Class)
                .SingleOrDefaultAsync(m => m.SectionId == id);
            if (sectionInfo == null)
            {
                return NotFound();
            }

            return View(sectionInfo);
        }

        // POST: SectionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectionInfo = await _context.SectionInfo.SingleOrDefaultAsync(m => m.SectionId == id);
            _context.SectionInfo.Remove(sectionInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectionInfoExists(int id)
        {
            return _context.SectionInfo.Any(e => e.SectionId == id);
        }
    }
}
