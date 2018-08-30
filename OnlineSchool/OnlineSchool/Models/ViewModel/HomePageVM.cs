using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSchool.Models.DataBaseModel;

namespace OnlineSchool.Models.ViewModel
{
    public class HomePageVM
    {
        public List<IndexViewModel> index { get; set; }
        public bool IsInstructor { get; set; }
        public int VisitorID { get; set; }
    }

    public class IndexViewModel
    {
        public string CourseName { get; set; }
        public string CategoryName { get; set; }
        public Boolean IsPaied { get; set; }
        public int InstructorCourseID { get; set; }
        public string ImgPath { get; set; }
    }
}