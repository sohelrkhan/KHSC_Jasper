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
    public class OtherCostInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public OtherCostInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: OtherCostInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OtherCostInfo.ToListAsync());
        }

        // GET: OtherCostInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherCostInfo = await _context.OtherCostInfo
                .SingleOrDefaultAsync(m => m.OcId == id);
            if (otherCostInfo == null)
            {
                return NotFound();
            }

            return View(otherCostInfo);
        }

        // GET: OtherCostInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OtherCostInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OcId,Date,ElectricityBillMonthName,ElectricityBillAmount,WaterBillMonth,WaterBillAmount,ItBill,FunctionCost,ScienceFairCost,StudyTourCost,PoorFund,SchoolDev,SchoolMaintenance,ServicingCharge,AnyCostName,AnyCostFee")] OtherCostInfo otherCostInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otherCostInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(otherCostInfo);
        }

        // GET: OtherCostInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherCostInfo = await _context.OtherCostInfo.SingleOrDefaultAsync(m => m.OcId == id);
            if (otherCostInfo == null)
            {
                return NotFound();
            }
            return View(otherCostInfo);
        }

        // POST: OtherCostInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OcId,Date,ElectricityBillMonthName,ElectricityBillAmount,WaterBillMonth,WaterBillAmount,ItBill,FunctionCost,ScienceFairCost,StudyTourCost,PoorFund,SchoolDev,SchoolMaintenance,ServicingCharge,AnyCostName,AnyCostFee")] OtherCostInfo otherCostInfo)
        {
            if (id != otherCostInfo.OcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherCostInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherCostInfoExists(otherCostInfo.OcId))
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
            return View(otherCostInfo);
        }

        // GET: OtherCostInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otherCostInfo = await _context.OtherCostInfo
                .SingleOrDefaultAsync(m => m.OcId == id);
            if (otherCostInfo == null)
            {
                return NotFound();
            }

            return View(otherCostInfo);
        }

        // POST: OtherCostInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otherCostInfo = await _context.OtherCostInfo.SingleOrDefaultAsync(m => m.OcId == id);
            _context.OtherCostInfo.Remove(otherCostInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherCostInfoExists(int id)
        {
            return _context.OtherCostInfo.Any(e => e.OcId == id);
        }
    }
}
