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
    public class ShiftInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public ShiftInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: ShiftInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShiftInfo.ToListAsync());
        }

        // GET: ShiftInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftInfo = await _context.ShiftInfo
                .SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shiftInfo == null)
            {
                return NotFound();
            }

            return View(shiftInfo);
        }

        // GET: ShiftInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShiftInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftId,ShiftName")] ShiftInfo shiftInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shiftInfo);
        }

        // GET: ShiftInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftInfo = await _context.ShiftInfo.SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shiftInfo == null)
            {
                return NotFound();
            }
            return View(shiftInfo);
        }

        // POST: ShiftInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftId,ShiftName")] ShiftInfo shiftInfo)
        {
            if (id != shiftInfo.ShiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftInfoExists(shiftInfo.ShiftId))
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
            return View(shiftInfo);
        }

        // GET: ShiftInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftInfo = await _context.ShiftInfo
                .SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shiftInfo == null)
            {
                return NotFound();
            }

            return View(shiftInfo);
        }

        // POST: ShiftInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftInfo = await _context.ShiftInfo.SingleOrDefaultAsync(m => m.ShiftId == id);
            _context.ShiftInfo.Remove(shiftInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftInfoExists(int id)
        {
            return _context.ShiftInfo.Any(e => e.ShiftId == id);
        }
    }
}
