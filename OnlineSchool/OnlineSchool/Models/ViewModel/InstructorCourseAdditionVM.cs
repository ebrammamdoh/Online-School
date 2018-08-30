using OnlineSchool.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class InstructorCourseAdditionVM
    {
        public int InstructorCourseVMID { get; set; }
        [Required]
        public int InstructorID { get; set; }
        [Required]
        public int CourseID { get; set; }
        public Nullable<int> Rate { get; set; }
        [Display(Name = "Coures Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Coures Name")]
        public string Title { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public List<Category> Categories { get; set; }
        public List<Course> Courses { get; set; }
    }
}