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
    public class StaffInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public StaffInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: StaffInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.StaffInfo.Include(s => s.Ss);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: StaffInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffInfo = await _context.StaffInfo
                .Include(s => s.Ss)
                .SingleOrDefaultAsync(m => m.SsId == id);
            if (staffInfo == null)
            {
                return NotFound();
            }

            return View(staffInfo);
        }

        // GET: StaffInfoes/Create
        public IActionResult Create()
        {
            ViewData["SsId"] = new SelectList(_context.StaffSalary, "SsId", "MonthName");
            return View();
        }

        // POST: StaffInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SsId,StaffId,StaffName,WorkingSector,Cell,Email,Address")] StaffInfo staffInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SsId"] = new SelectList(_context.StaffSalary, "SsId", "MonthName", staffInfo.SsId);
            return View(staffInfo);
        }

        // GET: StaffInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffInfo = await _context.StaffInfo.SingleOrDefaultAsync(m => m.SsId == id);
            if (staffInfo == null)
            {
                return NotFound();
            }
            ViewData["SsId"] = new SelectList(_context.StaffSalary, "SsId", "MonthName", staffInfo.SsId);
            return View(staffInfo);
        }

        // POST: StaffInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SsId,StaffId,StaffName,WorkingSector,Cell,Email,Address")] StaffInfo staffInfo)
        {
            if (id != staffInfo.SsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffInfoExists(staffInfo.SsId))
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
            ViewData["SsId"] = new SelectList(_context.StaffSalary, "SsId", "MonthName", staffInfo.SsId);
            return View(staffInfo);
        }

        // GET: StaffInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffInfo = await _context.StaffInfo
                .Include(s => s.Ss)
                .SingleOrDefaultAsync(m => m.SsId == id);
            if (staffInfo == null)
            {
                return NotFound();
            }

            return View(staffInfo);
        }

        // POST: StaffInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffInfo = await _context.StaffInfo.SingleOrDefaultAsync(m => m.SsId == id);
            _context.StaffInfo.Remove(staffInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffInfoExists(int id)
        {
            return _context.StaffInfo.Any(e => e.SsId == id);
        }
    }
}
