using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class CustomCourseVM
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
    }
    public class CustomCourseInstructorVM
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string ImgPath { get; set; }
    }
}