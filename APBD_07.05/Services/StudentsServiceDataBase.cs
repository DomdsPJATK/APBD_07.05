﻿using System;
using System.Linq;
using APBD_07._05.Model;
using APBD_19._03_CW3.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Services
{
    public class StudentsServiceDataBase : IStudentServiceDB
    {

        private readonly s19036Context _context;

        public StudentsServiceDataBase(s19036Context context)
        {
            _context = context;
        }


        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {
           throw new SystemException();
        }

        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var studiesId = _context.Studies.Where(studies => studies.Name == request.Studies.Name).Select(studies => new
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
            if(studentExist) return new BadRequestResult();

            return new OkObjectResult(_context.Student.Add(new Student()
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                IdEnrollment = enrollmentId
            }));

        }

        public IActionResult GetStudents()
        {
            var res = _context.Student.ToList();
            return new OkObjectResult(res);
        }

        public IActionResult ModifyStudent()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult DelStudent(string index)
        {
            _context.Student.Select()
        }
        
    }
    
}