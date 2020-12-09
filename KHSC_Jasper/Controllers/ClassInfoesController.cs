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
    public class ClassInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public ClassInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: ClassInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassInfo.ToListAsync());
        }

        // GET: ClassInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classInfo = await _context.ClassInfo
                .SingleOrDefaultAsync(m => m.ClassId == id);
            if (classInfo == null)
            {
                return NotFound();
            }

            return View(classInfo);
        }

        // GET: ClassInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName")] ClassInfo classInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classInfo);
        }

        // GET: ClassInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classInfo = await _context.ClassInfo.SingleOrDefaultAsync(m => m.ClassId == id);
            if (classInfo == null)
            {
                return NotFound();
            }
            return View(classInfo);
        }

        // POST: ClassInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName")] ClassInfo classInfo)
        {
            if (id != classInfo.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassInfoExists(classInfo.ClassId))
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
            return View(classInfo);
        }

        // GET: ClassInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classInfo = await _context.ClassInfo
                .SingleOrDefaultAsync(m => m.ClassId == id);
            if (classInfo == null)
            {
                return NotFound();
            }

            return View(classInfo);
        }

        // POST: ClassInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classInfo = await _context.ClassInfo.SingleOrDefaultAsync(m => m.ClassId == id);
            _context.ClassInfo.Remove(classInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassInfoExists(int id)
        {
            return _context.ClassInfo.Any(e => e.ClassId == id);
        }
    }
}
