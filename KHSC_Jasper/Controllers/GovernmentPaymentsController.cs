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
    public class GovernmentPaymentsController : Controller
    {
        private readonly KHSCDBContext _context;

        public GovernmentPaymentsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: GovernmentPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.GovernmentPayment.ToListAsync());
        }

        // GET: GovernmentPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentPayment = await _context.GovernmentPayment
                .SingleOrDefaultAsync(m => m.GpId == id);
            if (governmentPayment == null)
            {
                return NotFound();
            }

            return View(governmentPayment);
        }

        // GET: GovernmentPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GovernmentPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GpId,MonthName,Amount,Date")] GovernmentPayment governmentPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(governmentPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(governmentPayment);
        }

        // GET: GovernmentPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentPayment = await _context.GovernmentPayment.SingleOrDefaultAsync(m => m.GpId == id);
            if (governmentPayment == null)
            {
                return NotFound();
            }
            return View(governmentPayment);
        }

        // POST: GovernmentPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GpId,MonthName,Amount,Date")] GovernmentPayment governmentPayment)
        {
            if (id != governmentPayment.GpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(governmentPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GovernmentPaymentExists(governmentPayment.GpId))
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
            return View(governmentPayment);
        }

        // GET: GovernmentPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var governmentPayment = await _context.GovernmentPayment
                .SingleOrDefaultAsync(m => m.GpId == id);
            if (governmentPayment == null)
            {
                return NotFound();
            }

            return View(governmentPayment);
        }

        // POST: GovernmentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var governmentPayment = await _context.GovernmentPayment.SingleOrDefaultAsync(m => m.GpId == id);
            _context.GovernmentPayment.Remove(governmentPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GovernmentPaymentExists(int id)
        {
            return _context.GovernmentPayment.Any(e => e.GpId == id);
        }
    }
}
