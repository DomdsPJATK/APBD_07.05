using System;
using System.Linq;
using APBD_07._05.Model;
using APBD_19._03_CW3.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_07._05.Services
{
    public class EnrollmentStudentSql : IEnrollStudentDB
    {
        private readonly s19036Context _context;

        public EnrollmentStudentSql(s19036Context context)
        {
            _context = context;
        }

        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {
            var res = _context.Enrollment.Join(_context.Studies, enrollment => enrollment.IdStudy,
                studies => studies.IdStudy, ((enrollment, studies) => new
                {
                    studies.Name,
                    enrollment.Semester
                })).Where(res => res.Name == request.studies && res.Semester == request.semester);
            
            if(!res.Any()) return  new BadRequestResult();

            _context.Database.ExecuteSqlInterpolated($"exec promoteStudent {request.studies}, {request.semester}");
            _context.SaveChanges();

            return new OkObjectResult(request);
        }

        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var studiesId = _context.Studies.Where(studies => studies.Name == request.Studies.Name).Select(studies =>
                new
                {
                    studies.IdStudy
                }).First().IdStudy;

            var enrollRes = _context.Enrollment
                .Where(enrollment => enrollment.Semester == 1
                                     && enrollment.IdStudy == studiesId
                                     && enrollment.StartDate == _context.Enrollment
                                         .Where(enrollment1 =>
                                             enrollment.Semester == 1 && enrollment.IdStudy == studiesId)
                                         .Max(enrollment1 => enrollment.StartDate));

            int enrollmentId;
            if (!enrollRes.Any())
            {
                enrollmentId = _context.Enrollment.Max(enrollment => enrollment.IdEnrollment) + 1;
                _context.Add(new Enrollment()
                {
                    IdEnrollment = enrollmentId,
                    IdStudy = request.Studies.IdStudy,
                    Semester = 1,
                    StartDate = DateTime.Now
                });
            }
            else
                enrollmentId = enrollRes.Select(enrollment => enrollment.IdEnrollment).FirstOrDefault();

            var studentExist = _context.Student.Any(enrollment => enrollment.IndexNumber == request.IndexNumber);
            if (studentExist) return new BadRequestResult();

            var result = _context.Student.Add(new Student()
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                IdEnrollment = enrollmentId
            });
            _context.SaveChanges();

            return new OkObjectResult(result);
        }
    }
}