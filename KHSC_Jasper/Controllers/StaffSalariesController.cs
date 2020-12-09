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
    public class StaffSalariesController : Controller
    {
        private readonly KHSCDBContext _context;

        public StaffSalariesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: StaffSalaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffSalary.ToListAsync());
        }

        // GET: StaffSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSalary = await _context.StaffSalary
                .SingleOrDefaultAsync(m => m.SsId == id);
            if (staffSalary == null)
            {
                return NotFound();
            }

            return View(staffSalary);
        }

        // GET: StaffSalaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffSalaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SsId,StaffId,MonthName,Amount,Date")] StaffSalary staffSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffSalary);
        }

        // GET: StaffSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSalary = await _context.StaffSalary.SingleOrDefaultAsync(m => m.SsId == id);
            if (staffSalary == null)
            {
                return NotFound();
            }
            return View(staffSalary);
        }

        // POST: StaffSalaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SsId,StaffId,MonthName,Amount,Date")] StaffSalary staffSalary)
        {
            if (id != staffSalary.SsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffSalaryExists(staffSalary.SsId))
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
            return View(staffSalary);
        }

        // GET: StaffSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSalary = await _context.StaffSalary
                .SingleOrDefaultAsync(m => m.SsId == id);
            if (staffSalary == null)
            {
                return NotFound();
            }

            return View(staffSalary);
        }

        // POST: StaffSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffSalary = await _context.StaffSalary.SingleOrDefaultAsync(m => m.SsId == id);
            _context.StaffSalary.Remove(staffSalary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffSalaryExists(int id)
        {
            return _context.StaffSalary.Any(e => e.SsId == id);
        }
    }
}
