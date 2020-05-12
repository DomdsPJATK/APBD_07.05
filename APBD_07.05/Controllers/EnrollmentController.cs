using APBD_07._05.Services;
using APBD_19._03_CW3.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollStudentDB _service;
        
        public EnrollmentController(IEnrollStudentDB service)
        {
            _service = service;
        }
        
        [HttpPost("enrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            return _service.EnrollStudent(request);
        }
        
        [HttpPost("promoteStudent")]
        public IActionResult PromoteStudent(PromoteStudentRequest request)
        {
            return _service.PromoteStudent(request);
        }
        
    }
}