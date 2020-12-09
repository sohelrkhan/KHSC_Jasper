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
    public class AdmissionFormsController : Controller
    {
        private readonly KHSCDBContext _context;

        public AdmissionFormsController(KHSCDBContext context)
        {
            _context = context;
        }

        // GET: AdmissionForms
        
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdmissionForm.ToListAsync());
        }

        // GET: AdmissionForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionForm = await _context.AdmissionForm
                .SingleOrDefaultAsync(m => m.AfId == id);
            if (admissionForm == null)
            {
                return NotFound();
            }

            return View(admissionForm);
        }

        // GET: AdmissionForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdmissionForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfId,AdmitCardNo,AdmissionDate,CollegeRoll,Section,ElectiveSubject1,ElectiveSubject2,ElectiveSubject3,FourthSubject,NameOftheStudent,DateOfBirth,Religion,Nationality,Height,Weight,BloodGroup,FathersName,FathersEducationalQualification,FathersOccupation,FathersMobileNo,FatherNid,MothersName,MothersEducationalQualification,MothersOccupation,MothersMobileNo,MotherNid,PresentAddress,PermanentAddress,NameOfGuardian,GuardianAddress,GuardianMobileNo,FathersTotalAnnualincome,JscyearOfTheExam,JscnameOfTheBoard,JscroolNo,JscregistrationNo,Jscsession,JscGpa,JscnameOfInstitution,SscyearOfTheExam,SscnameOfTheBoard,SscroolNo,SscregistrationNo,Sscsession,SscGpa,SscnameOfInstitution,NameOfTheLastSchoolorCollegeAttended")] AdmissionForm admissionForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admissionForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admissionForm);
        }

        // GET: AdmissionForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionForm = await _context.AdmissionForm.SingleOrDefaultAsync(m => m.AfId == id);
            if (admissionForm == null)
            {
                return NotFound();
            }
            return View(admissionForm);
        }

        // POST: AdmissionForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfId,AdmitCardNo,AdmissionDate,CollegeRoll,Section,ElectiveSubject1,ElectiveSubject2,ElectiveSubject3,FourthSubject,NameOftheStudent,DateOfBirth,Religion,Nationality,Height,Weight,BloodGroup,FathersName,FathersEducationalQualification,FathersOccupation,FathersMobileNo,FatherNid,MothersName,MothersEducationalQualification,MothersOccupation,MothersMobileNo,MotherNid,PresentAddress,PermanentAddress,NameOfGuardian,GuardianAddress,GuardianMobileNo,FathersTotalAnnualincome,JscyearOfTheExam,JscnameOfTheBoard,JscroolNo,JscregistrationNo,Jscsession,JscGpa,JscnameOfInstitution,SscyearOfTheExam,SscnameOfTheBoard,SscroolNo,SscregistrationNo,Sscsession,SscGpa,SscnameOfInstitution,NameOfTheLastSchoolorCollegeAttended")] AdmissionForm admissionForm)
        {
            if (id != admissionForm.AfId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admissionForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionFormExists(admissionForm.AfId))
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
            return View(admissionForm);
        }

        // GET: AdmissionForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionForm = await _context.AdmissionForm
                .SingleOrDefaultAsync(m => m.AfId == id);
            if (admissionForm == null)
            {
                return NotFound();
            }

            return View(admissionForm);
        }

        // POST: AdmissionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admissionForm = await _context.AdmissionForm.SingleOrDefaultAsync(m => m.AfId == id);
            _context.AdmissionForm.Remove(admissionForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionFormExists(int id)
        {
            return _context.AdmissionForm.Any(e => e.AfId == id);
        }
    }
}
