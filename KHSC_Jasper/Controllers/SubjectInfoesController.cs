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
    public class SubjectInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public SubjectInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: SubjectInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.SubjectInfo.Include(s => s.Class).Include(s => s.Group);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: SubjectInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectInfo = await _context.SubjectInfo
                .Include(s => s.Class)
                .Include(s => s.Group)
                .SingleOrDefaultAsync(m => m.SubjectId == id);
            if (subjectInfo == null)
            {
                return NotFound();
            }

            return View(subjectInfo);
        }

        // GET: SubjectInfoes/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName");
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName");
            return View();
        }

        // POST: SubjectInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName,GroupId,ClassId")] SubjectInfo subjectInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", subjectInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", subjectInfo.GroupId);
            return View(subjectInfo);
        }

        // GET: SubjectInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectInfo = await _context.SubjectInfo.SingleOrDefaultAsync(m => m.SubjectId == id);
            if (subjectInfo == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", subjectInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", subjectInfo.GroupId);
            return View(subjectInfo);
        }

        // POST: SubjectInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName,GroupId,ClassId")] SubjectInfo subjectInfo)
        {
            if (id != subjectInfo.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectInfoExists(subjectInfo.SubjectId))
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
            ViewData["ClassId"] = new SelectList(_context.ClassInfo, "ClassId", "ClassName", subjectInfo.ClassId);
            ViewData["GroupId"] = new SelectList(_context.GroupInfo, "GroupId", "GroupName", subjectInfo.GroupId);
            return View(subjectInfo);
        }

        // GET: SubjectInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectInfo = await _context.SubjectInfo
                .Include(s => s.Class)
                .Include(s => s.Group)
                .SingleOrDefaultAsync(m => m.SubjectId == id);
            if (subjectInfo == null)
            {
                return NotFound();
            }

            return View(subjectInfo);
        }

        // POST: SubjectInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjectInfo = await _context.SubjectInfo.SingleOrDefaultAsync(m => m.SubjectId == id);
            _context.SubjectInfo.Remove(subjectInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectInfoExists(int id)
        {
            return _context.SubjectInfo.Any(e => e.SubjectId == id);
        }
    }
}
