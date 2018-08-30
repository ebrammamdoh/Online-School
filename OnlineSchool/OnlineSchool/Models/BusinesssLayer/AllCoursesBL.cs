using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models.BusinesssLayer
{
    public class AllCoursesBL
    {
        //int PageSize = 5;
        OnlineSchoolEntities context = new OnlineSchoolEntities();
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
        public List<CustomCourseVM> GetLatestCourses()
        {
            List<CustomCourseVM> lst = new List<CustomCourseVM>();
            var query = (from lt in context.InstructorCoures
                         select new
                         {
                             CourseID=lt.CourseID,
                             CourseName=lt.Title,
                             CreationDate=lt.CreationDate,
                             
                         }
                         
                         ).OrderByDescending(c=>c.CreationDate).Take(5);
            foreach (var item in query)
            {
                lst.Add(new CustomCourseVM
                {
                    CourseID=item.CourseID,
                    CourseName=item.CourseName,
                });
            }
            return lst;
        }
        public List<CustomCourseInstructorVM> GetMostViewed()
        {
            List<CustomCourseInstructorVM> lst = new List<CustomCourseInstructorVM>();
            var query = (from lt in context.InstructorCoures
                         select new
                         {
                             CourseID = lt.CourseID,
                             CourseName = lt.Title,
                             InstructorName=(from inst in context.Instructors
                                             where inst.InstructorID==lt.InstructorID
                                             select inst.FullName).FirstOrDefault(),
                             MostViewed = lt.StudentIntakes.Count,
                             ImgPath = lt.ImgPath,
                         }

                         ).OrderByDescending(c => c.MostViewed).Take(5);
            foreach (var item in query)
            {
                lst.Add(new CustomCourseInstructorVM
                {
                    CourseID = item.CourseID,
                    CourseName = item.CourseName,
                    InstructorName=item.InstructorName,
                    ImgPath=item.ImgPath,
                });
            }
            return lst;
        }
        public List<SubInstructorCourses> GetCoursesDetails()
        {
            List<SubInstructorCourses> lst = new List<SubInstructorCourses>();
            var query = (from lt in context.InstructorCoures
                         select new
                         {
                             CourseID = lt.CourseID,
                             CourseName = lt.Title,
                             InstructorName = (from inst in context.Instructors
                                               where inst.InstructorID == lt.InstructorID
                                               select inst.FullName).FirstOrDefault(),
                             InstructorID = lt.InstructorID,
                             NoOfStudents=lt.StudentIntakes.Count,
                             ImgPath = lt.ImgPath,
                         }

                         );
            foreach (var item in query)
            {
                lst.Add(new SubInstructorCourses
                {
                    CourseID = item.CourseID,
                    CourseName = item.CourseName,
                    InstructorName = item.InstructorName,
                    InstructorID= item.InstructorID,
                    NoOfStudents=item.NoOfStudents,
                    ImgPath=item.ImgPath,
                });
            }
            return lst;
        }
        public List<SubInstructorCourses> GetCoursesDetailsByCourseID(int CourseID)
        {
            List<SubInstructorCourses> lst = new List<SubInstructorCourses>();
            var query = (from lt in context.InstructorCoures
                         where lt.CourseID==CourseID
                         select new
                         {
                             CourseID = lt.CourseID,
                             CourseName = lt.Title,
                             InstructorName = (from inst in context.Instructors
                                               where inst.InstructorID == lt.InstructorID
                                               select inst.FullName).FirstOrDefault(),
                             InstructorID = lt.InstructorID,
                             NoOfStudents = lt.StudentIntakes.Count,
                             ImgPath = lt.ImgPath,
                         }

                         );
            foreach (var item in query)
            {
                lst.Add(new SubInstructorCourses
                {
                    CourseID = item.CourseID,
                    CourseName = item.CourseName,
                    InstructorName = item.InstructorName,
                    InstructorID = item.InstructorID,
                    NoOfStudents = item.NoOfStudents,
                    ImgPath=item.ImgPath,
                });
            }
            return lst;
        }
        
     
     }
}