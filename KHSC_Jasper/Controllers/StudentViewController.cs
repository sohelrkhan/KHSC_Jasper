using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KHSC_Jasper.Filters;
using KHSC_Jasper.Models;
using KHSC_Jasper.ViewModel;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KHSC_Jasper.Controllers
{
    [AttachViewData]
    public class StudentViewController : Controller
    {
         private readonly KHSCDBContext _context;
            public StudentViewController(KHSCDBContext context)
            {
                _context = context;
            }

            // GET: Results

            public IActionResult HalfYear()
            {
                      var result = (from h in _context.HalfYearResult

                                  join s in _context.StudentInfo
                                  on h.StudentId equals s.StudentId

                                  join e in _context.Enrollment
                                  on s.StudentId equals e.StudentId

                                    select new HalfYearResultViewModel
                                  {
                                      StudentId = h.StudentId,
                                      StudentName = s.StudentName,
                                      Ct1 = h.Ct1,
                                      Sub = h.Sub,
                                      Obj = h.Obj,
                                      Practical = h.Practical,
                                      Attendence = h.Attendence
                                    }).ToList();
                    return View(result);
                }

        public IActionResult YearFinal()
        {
            var result = (from f in _context.FinalYearResult

                          join s in _context.StudentInfo
                          on f.StudentId equals s.StudentId

                          join e in _context.Enrollment
                          on s.StudentId equals e.StudentId

                          select new YearFinalResultViewModel
                          {
                              StudentId = f.StudentId,
                              StudentName = s.StudentName,
                              Ct2 = f.Ct2,
                              Sub = f.Sub,
                              Obj = f.Obj,
                              Practical = f.Practical,
                              Attendance = f.Attendance
                          }).ToList();
            return View(result);
        }
        public IActionResult Pretest()
        {
            var result = (from p in _context.Pretest

                          join s in _context.StudentInfo
                          on p.StudentId equals s.StudentId

                          join e in _context.Enrollment
                          on s.StudentId equals e.StudentId

                          select new PretestResultViewModel
                          {
                              StudentId = p.StudentId,
                              StudentName = s.StudentName,                            
                              Sub = p.Sub,
                              Obj = p.Obj,
                              Practical = p.Practical,
                              Attendance = p.Attendance
                          }).ToList();
            return View(result);
        }
        public IActionResult Test()
        {
            var result = (from t in _context.Test

                          join s in _context.StudentInfo
                          on t.StudentId equals s.StudentId

                          join e in _context.Enrollment
                          on s.StudentId equals e.StudentId

                          select new TestResultViewModel
                          {
                              StudentId = t.StudentId,
                              StudentName = s.StudentName,

                              Sub = t.Sub,
                              Obj = t.Obj,
                              Practical = t.Practical,
                              Attendance = t.Attendance
                          }).ToList();
            return View(result);
        }
    }
}
