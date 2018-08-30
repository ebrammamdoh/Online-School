using OnlineSchool.Models;
using OnlineSchool.Models.BusinesssLayer;
using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class HomeController : Controller
    {
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        AllCoursesBL allCoursesBL = new AllCoursesBL();
        HomePageVM homePageVM = new HomePageVM();
        public ActionResult Index()
        {
            Login log = new Login();
            homePageVM.index =
                (
                from crs in context.Categories
                 from sub in context.Courses
                 from asd in context.InstructorCoures
                 from inst in context.Instructors
                 where (crs.CategoryID == sub.CategoryID && sub.CourseID == asd.CourseID
                 && asd.InstructorID == inst.InstructorID)
                 select new IndexViewModel()
                 {
                     CourseName = sub.CourseName,
                     CategoryName = crs.CategoryName,
                     IsPaied = asd.IsPaied,
                     InstructorCourseID = asd.InstructorCourseID,
                     ImgPath=asd.ImgPath,
                 }).Take(8).ToList();
            if(User.Identity.IsAuthenticated==true)
            {
                var result = log.FindVisitor(User.Identity.Name);
                homePageVM.IsInstructor = result.IsInstructor;
                homePageVM.VisitorID = result.VisitorID;
            }
            
            return View(homePageVM);
        }
        [HttpGet]
        public ActionResult Courses()
        {
            AllCoursesVM AllCors = new AllCoursesVM();
            AllCors.Categories = allCoursesBL.GetAllCategories();
            AllCors.LatestCourses = allCoursesBL.GetLatestCourses();
            AllCors.MostWatched = allCoursesBL.GetMostViewed();
            AllCors.CoursesDetails = allCoursesBL.GetCoursesDetails();
            //AllCors.TotalPages = allCoursesBL.TotalPages;
            return View(AllCors);
        }

        public JsonResult GetCoursesByCategoryID(int id)
        {
            List<CustomCourseVM> courses = allCoursesBL.GetAllCoursesByCategoryID(id);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllCoursesByCourseID(int corsID)
        {
            List<SubInstructorCourses> courses = allCoursesBL.GetCoursesDetailsByCourseID(corsID);

            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        

        //[HttpPost]
        //public ActionResult Courses(int HiddenCourseID)
        //{
        //    AllCoursesVM AllCors = new AllCoursesVM();
        //    AllCors.Categories = allCoursesBL.GetAllCategories();
        //    AllCors.LatestCourses = allCoursesBL.GetLatestCourses();
        //    AllCors.MostWatched = allCoursesBL.GetMostViewed();
        //    AllCors.CoursesDetails = allCoursesBL.GetCoursesDetailsByCourseID(HiddenCourseID);

        //    return View(AllCors);
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}