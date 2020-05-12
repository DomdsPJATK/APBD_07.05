using APBD_19._03_CW3.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Services
{
    public interface IEnrollStudentDB
    {
        IActionResult PromoteStudent(PromoteStudentRequest request);
        IActionResult EnrollStudent(EnrollStudentRequest request);
    }
}