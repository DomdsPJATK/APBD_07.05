using System;
using System.ComponentModel.DataAnnotations;

namespace APBD_07._05.DTO.Request
{
    public class ModifiedStudentRequest
    {
        [Required]
        public string IndexNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int IdEnrollment { get; set; }
        [Required]
        public string Password { get; set; }
    }
}