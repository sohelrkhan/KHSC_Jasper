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
    public class ExamInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public ExamInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: ExamInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExamInfo.ToListAsync());
        }

        // GET: ExamInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examInfo = await _context.ExamInfo
                .SingleOrDefaultAsync(m => m.ExamId == id);
            if (examInfo == null)
            {
                return NotFound();
            }

            return View(examInfo);
        }

        // GET: ExamInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,ExamName")] ExamInfo examInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examInfo);
        }

        // GET: ExamInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examInfo = await _context.ExamInfo.SingleOrDefaultAsync(m => m.ExamId == id);
            if (examInfo == null)
            {
                return NotFound();
            }
            return View(examInfo);
        }

        // POST: ExamInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExamId,ExamName")] ExamInfo examInfo)
        {
            if (id != examInfo.ExamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamInfoExists(examInfo.ExamId))
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
            return View(examInfo);
        }

        // GET: ExamInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examInfo = await _context.ExamInfo
                .SingleOrDefaultAsync(m => m.ExamId == id);
            if (examInfo == null)
            {
                return NotFound();
            }

            return View(examInfo);
        }

        // POST: ExamInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examInfo = await _context.ExamInfo.SingleOrDefaultAsync(m => m.ExamId == id);
            _context.ExamInfo.Remove(examInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamInfoExists(int id)
        {
            return _context.ExamInfo.Any(e => e.ExamId == id);
        }
    }
}
