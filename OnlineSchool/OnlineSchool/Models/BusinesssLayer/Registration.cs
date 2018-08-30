using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.BusinesssLayer
{
    public class Registration
    {
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        public int AddNew(RegisterViewModel regist)
        {
            if (regist.IsInstructor == true)
            {
                Instructor inst = new Instructor();
                inst.FullName = regist.FullName;
                inst.Email = regist.Email;
                inst.Password = regist.Password;
                inst.Gender = regist.Gender;
                inst.RegisterationDate = DateTime.Now;
                inst.CountryID = null;
                context.Instructors.Add(inst);
                return context.SaveChanges();
            }
            else
            {
                Student stud = new Student();
                stud.FullName = regist.FullName;
                stud.Email = regist.Email;
                stud.Password = regist.Password;
                stud.Gender = regist.Gender;
                stud.RegisterationDate = DateTime.Now;
                context.Students.Add(stud);
                return context.SaveChanges();
            }
        }
        public int GetRegistereedID(RegisterViewModel regist)
        {
            if (regist.IsInstructor == true)
                return context.Instructors.Where(s => s.FullName == regist.FullName).FirstOrDefault().InstructorID;
            else
                return context.Students.Where(s => s.FullName == regist.FullName).FirstOrDefault().StudentID;
        }
    }
}