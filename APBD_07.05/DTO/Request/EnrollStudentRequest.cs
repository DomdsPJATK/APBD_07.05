﻿using System;
using System.ComponentModel.DataAnnotations;
 using APBD_07._05.Model;

 namespace APBD_19._03_CW3.DTOs.Request
{
    public class EnrollStudentRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IndexNumber { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public Studies Studies { get; set; }
    }
}