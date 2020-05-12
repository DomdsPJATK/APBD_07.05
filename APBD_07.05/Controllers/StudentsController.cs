using System;
using System.ComponentModel;
using System.Linq;
using APBD_07._05.DTO.Request;
using APBD_07._05.Model;
using APBD_07._05.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Controllers
{
    [ApiController]
    [Route("/api/students")]
    
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServiceDB _service;
        
        public StudentsController(IStudentServiceDB service)
        {
            _service = service;
        }

        [HttpGet("getStudents")]
        public IActionResult GetStudents()
        {
            return _service.GetStudents();
        }
        
        [HttpPost("modifyStudent")]
        public IActionResult modifyStudents(ModifiedStudentRequest request)
        {
            Console.WriteLine(request);
            return new OkObjectResult(_service.ModifyStudent(request));
        }

        [HttpGet("removeStudent/{index}")]
        public IActionResult removeStudent(string index)
        {
            return _service.DelStudent(index);
        }

    }
    
}