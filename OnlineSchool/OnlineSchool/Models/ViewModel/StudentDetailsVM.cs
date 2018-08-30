using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineSchool.Models.DataBaseModel;

namespace OnlineSchool.Models.ViewModel
{
    public class StudentDetailsVM
    {
        public int StudentID { get; set; }
        //[Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        public string Picture { get; set; }
        public int? CountryID { get; set; }
        public DateTime RegisterationDate { get; set; }
        /// <summary>
        public List<Country> countries { get; set; }
        /// </summary>
    }
}