using OnlineSchool.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class AllCoursesVM
    {
        public List<Category> Categories { get; set; }
        public List<SubInstructorCourses> CoursesDetails { get; set; }
        public List<CustomCourseVM> LatestCourses { get; set; }
        public List<CustomCourseInstructorVM> MostWatched { get; set; }

    }
    public class SubInstructorCourses
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int InstructorID { get; set; }
        public string InstructorName { get; set; }
        public int NoOfStudents { get; set; }
        public string ImgPath { get; set; }
    }
}