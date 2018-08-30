using OnlineSchool.Models.BusinesssLayer;
using OnlineSchool.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class InstructorDetailsVM
    {
        public int InstructorID { get; set; }
        //[Required]
        public string FullName { get; set; }
        public string Picture { get; set; }
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string JobTitle { get; set; }
        //[Range(0, 2000, ErrorMessage = "The maximun lenght is 2000 character")]
        public string JobDescription { get; set; }
        public int? CountryID { get; set; }
        public DateTime RegisterationDate { get; set; }
        /// <summary>
        public List<Country> countries { get; set; }
        public List<Course> Courses { get; set; }
        /// </summary>
        

    }
}