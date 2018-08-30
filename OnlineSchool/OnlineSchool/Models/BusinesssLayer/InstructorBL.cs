using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.BusinesssLayer
{
    public class InstructorBL
    {
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        public List<Country> GetAllCountries()
        {
            return context.Countries.ToList();
        }
        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
        public List<CustomCourseVM> GetAllCoursesByCategoryID(int catID)
        {
            List<CustomCourseVM> custCourse = new List<CustomCourseVM>();
            foreach (Course item in context.Courses.Where(c => c.CategoryID == catID).ToList())
            {
                custCourse.Add(new CustomCourseVM
                {
                    CourseID = item.CourseID,
                    CourseName = item.CourseName,
                });
            }
            return custCourse;
        }
        public Instructor GetInstructorByID(int instructorID)
        {
            return context.Instructors.Where(i => i.InstructorID == instructorID).FirstOrDefault();
        }
        public bool UpdateInstructor(Instructor instructor)
        {
            Instructor inst = context.Instructors.Where(i => i.InstructorID == instructor.InstructorID).FirstOrDefault();
            inst.JobTitle = instructor.JobTitle;
            inst.JobDescription = instructor.JobDescription;
            inst.Picture = instructor.Picture;
            inst.FullName = instructor.FullName;
            inst.CountryID = instructor.CountryID;
            inst.BirthDate = instructor.BirthDate;
            return context.SaveChanges() > 0 ? true : false;
        }
        public CoursesVM LoadInstructorCourses(int instructorID)
        {
            CoursesVM cvm = new CoursesVM();
            
            var InstructorCourses = from cors in context.InstructorCoures
                         where cors.InstructorID == instructorID
                         select new
                            {
                                Title=cors.Title,
                                StudentCounts=cors.StudentIntakes.Count,
                                CreationDate=cors.CreationDate,

                                Course = (from course in context.Courses
                                where course.CourseID==cors.CourseID
                                              select new { CourseName = course.CourseName, CourseID=course.CourseID}).FirstOrDefault()

                            };

            
            cvm.InstructorID = instructorID;
            foreach (var item in InstructorCourses)
            {
                InstructorCourseVM ivm = new InstructorCourseVM();
                ivm.CourseID = item.Course.CourseID;
                ivm.CourseName = item.Course.CourseName;
                ivm.Title = item.Title;
                ivm.StudentsCounts = item.StudentCounts;
                ivm.CreationDate = item.CreationDate;
               

                cvm.InstructorCourses.Add(ivm); 
                
            }

            return cvm;
        }
    }
}