using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class RegistrationVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool IsInstructor { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}