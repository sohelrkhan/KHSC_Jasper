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
    public class UserAccountsController : Controller
    {
        private readonly KHSCDBContext _context;

        public UserAccountsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: UserAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserAccounts.ToListAsync());
        }

        // GET: UserAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccounts = await _context.UserAccounts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userAccounts == null)
            {
                return NotFound();
            }

            return View(userAccounts);
        }

        // GET: UserAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,ConfirmPassword,UserRole")] UserAccounts userAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccounts);
        }

        // GET: UserAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccounts = await _context.UserAccounts.SingleOrDefaultAsync(m => m.Id == id);
            if (userAccounts == null)
            {
                return NotFound();
            }
            return View(userAccounts);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password,ConfirmPassword,UserRole")] UserAccounts userAccounts)
        {
            if (id != userAccounts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountsExists(userAccounts.Id))
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
            return View(userAccounts);
        }

        // GET: UserAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccounts = await _context.UserAccounts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (userAccounts == null)
            {
                return NotFound();
            }

            return View(userAccounts);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccounts = await _context.UserAccounts.SingleOrDefaultAsync(m => m.Id == id);
            _context.UserAccounts.Remove(userAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountsExists(int id)
        {
            return _context.UserAccounts.Any(e => e.Id == id);
        }
    }
}
