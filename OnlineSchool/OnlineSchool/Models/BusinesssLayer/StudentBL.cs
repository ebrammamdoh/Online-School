using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineSchool.Models.DataBaseModel;

namespace OnlineSchool.Models.BusinesssLayer
{
    public class StudentBL
    {
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        public List<Country> GetAllCountries()
        {
            return context.Countries.ToList();
        }
        public Student GetStudentByID(int StudentID)
        {
            return context.Students.Where(i => i.StudentID == StudentID).FirstOrDefault();
        }

        public bool UpdateStudent(Student student)
        {
            Student std = context.Students.Where(i => i.StudentID == student.StudentID).FirstOrDefault();
            std.Picture = student.Picture;
            std.FullName = student.FullName;
            std.CountryID = student.CountryID;
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}