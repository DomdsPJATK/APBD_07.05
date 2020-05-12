using APBD_07._05.DTO.Request;
using APBD_19._03_CW3.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Services
{
    public interface IStudentServiceDB
    {
        public IActionResult GetStudents();
        IActionResult ModifyStudent(ModifiedStudentRequest request);
        IActionResult DelStudent(string index);
    }
}