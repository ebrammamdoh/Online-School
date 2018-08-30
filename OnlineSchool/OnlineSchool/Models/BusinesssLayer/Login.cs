using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;

namespace OnlineSchool.Models.BusinesssLayer
{
    
    public class Login
    {
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        public CustomVisitor FindVisitor(LoginViewModel login)
        {
            //Instructor inst = new Instructor();
            //Student std = new Student();
            var query1 = context.Students.FirstOrDefault(a => a.FullName == login.UserName && a.Password == login.Password);
            var query2 = context.Instructors.FirstOrDefault(a => a.FullName == login.UserName && a.Password == login.Password);
            if (query1 != null)
            {
                return new CustomVisitor { IsInstructor = false, VisitorID = query1.StudentID };
            }
            else if (query2 != null)
            {
                return new CustomVisitor { IsInstructor = true, VisitorID = query2.InstructorID };
            }
            else
                return new CustomVisitor();
        }
        public CustomVisitor FindVisitor(string name)
        {
            var query1 = context.Students.FirstOrDefault(a => a.FullName == name);
            var query2 = context.Instructors.FirstOrDefault(a => a.FullName == name);
            if (query1 != null)
            {
                return new CustomVisitor { IsInstructor = false, VisitorID = query1.StudentID };
            }
            else if (query2 != null)
            {
                return new CustomVisitor { IsInstructor = true, VisitorID = query2.InstructorID };
            }
            else
                return new CustomVisitor();
        }
    }
    public class CustomVisitor
    {
        public int VisitorID { get; set; }
        public bool IsInstructor { get; set; }
    }
}