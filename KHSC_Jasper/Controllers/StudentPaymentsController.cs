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
    public class StudentPaymentsController : Controller
    {
        private readonly KHSCDBContext _context;

        public StudentPaymentsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: StudentPayments
        public async Task<IActionResult> Index()
        {
            var kHSCDBContext = _context.StudentPayment.Include(s => s.Student);
            return View(await kHSCDBContext.ToListAsync());
        }

        // GET: StudentPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayment
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.SpId == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // GET: StudentPayments/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName");
            return View();
        }

        // POST: StudentPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpId,StudentId,Date,FormFee,AdmissionFee,ReAdmissionFee,TcCharge,SeasonCharge,CertificateFee,TestimonialFee,WhichMonthFee,MonthFeeAmount,Ct1Fee,Ct2Fee,HalfYearlyFee,FinalYearlyFee,WaterElectricityFee,Tex,DevlopmentFee,BuildingDevFee,LabFee,LibraryFee,ComputerFee,RegistrationFee,CautionMoney,Fine,ReportCardFee,AdmitCardFee,IdCardFee,FormFillUpEFf,FormFillUpJsc,FormFillUpSsc,FormFillUpHsc,ItFee,ScienceDevelopmentFee,CareFee,OtherFeeName,OtherFeeAmount")] StudentPayment studentPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentPayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", studentPayment.StudentId);
            return View(studentPayment);
        }

        // GET: StudentPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayment.SingleOrDefaultAsync(m => m.SpId == id);
            if (studentPayment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", studentPayment.StudentId);
            return View(studentPayment);
        }

        // POST: StudentPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpId,StudentId,Date,FormFee,AdmissionFee,ReAdmissionFee,TcCharge,SeasonCharge,CertificateFee,TestimonialFee,WhichMonthFee,MonthFeeAmount,Ct1Fee,Ct2Fee,HalfYearlyFee,FinalYearlyFee,WaterElectricityFee,Tex,DevlopmentFee,BuildingDevFee,LabFee,LibraryFee,ComputerFee,RegistrationFee,CautionMoney,Fine,ReportCardFee,AdmitCardFee,IdCardFee,FormFillUpEFf,FormFillUpJsc,FormFillUpSsc,FormFillUpHsc,ItFee,ScienceDevelopmentFee,CareFee,OtherFeeName,OtherFeeAmount")] StudentPayment studentPayment)
        {
            if (id != studentPayment.SpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentPaymentExists(studentPayment.SpId))
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
            ViewData["StudentId"] = new SelectList(_context.StudentInfo, "StudentId", "StudentName", studentPayment.StudentId);
            return View(studentPayment);
        }

        // GET: StudentPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentPayment = await _context.StudentPayment
                .Include(s => s.Student)
                .SingleOrDefaultAsync(m => m.SpId == id);
            if (studentPayment == null)
            {
                return NotFound();
            }

            return View(studentPayment);
        }

        // POST: StudentPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentPayment = await _context.StudentPayment.SingleOrDefaultAsync(m => m.SpId == id);
            _context.StudentPayment.Remove(studentPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentPaymentExists(int id)
        {
            return _context.StudentPayment.Any(e => e.SpId == id);
        }
    }
}
