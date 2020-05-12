using System;
using System.Linq;
using APBD_07._05.DTO.Request;
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

        public IActionResult GetStudents()
        {
            return new OkObjectResult(_context.Student.ToList());
        }

        public IActionResult ModifyStudent(ModifiedStudentRequest request)
        {
            var toModify = _context.Student.FirstOrDefault(student => student.IndexNumber == request.IndexNumber);
            if (toModify != null)
            {
                toModify.IndexNumber = request.IndexNumber;
                toModify.FirstName = request.FirstName;
                toModify.LastName = request.LastName;
                toModify.Password = request.Password;
                toModify.BirthDate = request.BirthDate;
                toModify.IdEnrollment = request.IdEnrollment;
            }

            _context.SaveChanges();
            return new OkObjectResult(toModify);
        }

        public IActionResult DelStudent(string index)
        {
            var toDelete = _context.Student.Where(student => student.IndexNumber == index);
            
            if (!toDelete.Any()) return new NotFoundResult();
            
            _context.Student.Remove(toDelete.First());
            _context.SaveChanges();
            return new OkResult();
        }
    }
}