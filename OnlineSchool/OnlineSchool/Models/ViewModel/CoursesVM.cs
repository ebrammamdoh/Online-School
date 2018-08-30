using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class CoursesVM
    {
        public int InstructorID { get; set; }
        public List<InstructorCourseVM> InstructorCourses = new List<InstructorCourseVM>();

    }
    public class InstructorCourseVM
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public int StudentsCounts { get; set; }
        public int NoOfSegments { get; set; }
    }
}