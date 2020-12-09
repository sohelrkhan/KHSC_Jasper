using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KHSC_Jasper.Filters;
using KHSC_Jasper.Models;

namespace KHSC_Jasper.Controllers
{
    [AttachViewData]
    public class AuthController : Controller
    {
        private readonly KHSCDBContext _context;

        public AuthController(KHSCDBContext _context)
        {
            this._context = _context ?? throw new ArgumentNullException(nameof(_context));
        }
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Username, Password")] UserAccounts userAccount)
        {
            try
            {
                UserAccounts user = (from usr in _context.UserAccounts
                                   where usr.Username == userAccount.Username
                                   && usr.Password == userAccount.Password
                                   select usr).First<UserAccounts>();
                if (user != null)
                {
                    HttpContext.Session.SetInt32("IsAuthenticated", 1);
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetInt32("role", (int)user.UserRole);
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    ViewBag.Message = "Invalid username/password";
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        [IsAuthenticated]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("IsAuthenticated");
            HttpContext.Session.Remove("role");

            return RedirectToAction(nameof(Index));
        }
    }
}