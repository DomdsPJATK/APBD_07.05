using System.ComponentModel;
using System.Linq;
using APBD_07._05.Model;
using APBD_07._05.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_07._05.Controllers
{
    [ApiController]
    [Route("/api/students")]
    
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServiceDB _context;
        
        public StudentsController(IStudentServiceDB context)
        {
            _context = context;
        }

        [HttpGet("getStudents")]
        public IActionResult GetStudents()
        {
            return _context.GetStudents();
        }
        
        [HttpPost("modifyStudent")]
        public IActionResult modifyStudents()
        {
            return _context.ModifyStudent();
        }

        [HttpPost("removeStudent/{id}")]
        public IActionResult removeStudent(string index)
        {
            return _context.DelStudent(index);
        }
        
        
        
    }
    
}