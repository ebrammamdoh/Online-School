using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class CoursePageVM
    {
        public List<listofsegment> index { get; set; }
        public string JobTitle { get; set; }
        public string InstructorName { get; set; }
        public string JobDescription { get; set; }
    }

    public class listofsegment
    {
        public string Description { get; set; }
        public string CourseName { get; set; }
        public int InstructorID { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string comment { get; set; }
    }
}