using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.ViewModel
{
    public class CoursesPagingInfoVM
    {
        public List<SubInstructorCourses> courses { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }
}