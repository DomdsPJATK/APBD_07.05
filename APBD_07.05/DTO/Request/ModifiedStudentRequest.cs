using System;
using System.ComponentModel.DataAnnotations;
using APBD_19._03_CW3.DAL;
using Newtonsoft.Json;

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
        [JsonConverter(typeof(CustonDateTimeConverter))]
        public DateTime BirthDate { get; set; }
        [Required]
        public int IdEnrollment { get; set; }
        [Required]
        public string Password { get; set; }
    }
}