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
    public class GroupInfoesController : Controller
    {
        private readonly KHSCDBContext _context;

        public GroupInfoesController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: GroupInfoes
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.GroupInfo.Include(g => g.Section);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: GroupInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.GroupInfo
                .Include(g => g.Section)
                .SingleOrDefaultAsync(m => m.GroupId == id);
            if (groupInfo == null)
            {
                return NotFound();
            }

            return View(groupInfo);
        }

        // GET: GroupInfoes/Create
        public IActionResult Create()
        {
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName");
            return View();
        }

        // POST: GroupInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupName,SectionId")] GroupInfo groupInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", groupInfo.SectionId);
            return View(groupInfo);
        }

        // GET: GroupInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.GroupInfo.SingleOrDefaultAsync(m => m.GroupId == id);
            if (groupInfo == null)
            {
                return NotFound();
            }
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", groupInfo.SectionId);
            return View(groupInfo);
        }

        // POST: GroupInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,GroupName,SectionId")] GroupInfo groupInfo)
        {
            if (id != groupInfo.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupInfoExists(groupInfo.GroupId))
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
            ViewData["SectionId"] = new SelectList(_context.SectionInfo, "SectionId", "SectionName", groupInfo.SectionId);
            return View(groupInfo);
        }

        // GET: GroupInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInfo = await _context.GroupInfo
                .Include(g => g.Section)
                .SingleOrDefaultAsync(m => m.GroupId == id);
            if (groupInfo == null)
            {
                return NotFound();
            }

            return View(groupInfo);
        }

        // POST: GroupInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupInfo = await _context.GroupInfo.SingleOrDefaultAsync(m => m.GroupId == id);
            _context.GroupInfo.Remove(groupInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupInfoExists(int id)
        {
            return _context.GroupInfo.Any(e => e.GroupId == id);
        }
    }
}
