using OnlineSchool.Models.BusinesssLayer;
using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    [Authorize]//(Roles="Instructors")]
    public class InstructorController : Controller
    {
        //
        // GET: /Instructor/
        InstructorBL instructorBL = new InstructorBL();
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Login log = new Login();
            var result = log.FindVisitor(User.Identity.Name);
            if(result.VisitorID==id)
            {
                InstructorDetailsVM model = new InstructorDetailsVM();
                model.countries = instructorBL.GetAllCountries();

                Instructor inst = instructorBL.GetInstructorByID(id);
                model.BirthDate = inst.BirthDate;
                model.CountryID = inst.CountryID;
                model.Email = inst.Email;
                model.FullName = inst.FullName;
                model.InstructorID = inst.InstructorID;
                model.JobDescription = inst.JobDescription;
                model.JobTitle = inst.JobTitle;
                model.Picture = inst.Picture;
                model.RegisterationDate = inst.RegisterationDate;

                return View(model);
            }
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public ActionResult Edit(InstructorDetailsVM instructorVM, HttpPostedFileBase uploadimage)
        {
            //InstructorBL instructorBL;
            string path = Path.Combine(Server.MapPath("~/Images"), uploadimage.FileName);
            uploadimage.SaveAs(path);
            

            Instructor inst = new Instructor();
            inst.InstructorID = instructorVM.InstructorID;
            inst.BirthDate = instructorVM.BirthDate;
            inst.CountryID = instructorVM.CountryID;
           /// inst.Email = instructorVM.Email;
            inst.FullName = instructorVM.FullName;
            inst.JobDescription = instructorVM.JobDescription;
            inst.JobTitle = instructorVM.JobTitle;
            inst.Picture = uploadimage.FileName;
            instructorVM.countries = instructorBL.GetAllCountries();
            if (ModelState.IsValid)
            {
                //instructorBL = new InstructorBL();
                bool chk = instructorBL.UpdateInstructor(inst);
                if (chk)
                    return RedirectToAction("Edit");
                else
                    return View(instructorVM);

            }
            else
                return View(instructorVM);
        }
        [HttpGet]
        public ActionResult Course(int id)
        {
            CoursesVM model = instructorBL.LoadInstructorCourses(id);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Course(Course course)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            InstructorCourseAdditionVM ica = new InstructorCourseAdditionVM();
            ica.Categories = instructorBL.GetAllCategories();
            ica.CourseID = 0;
            return View(ica);
        }
        public JsonResult GetCoursesByCategoryID(int id)
        {
            List<CustomCourseVM> courses = instructorBL.GetAllCoursesByCategoryID(id);
            
            //return Json(courses.Select(x => new
            //{
            //    CourseID = x.CourseID,
            //    CourseName = x.CourseName
            //}));
            return Json( courses , JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            return View();
        }
        CoursePageVM coursePageVM = new CoursePageVM();
        OnlineSchoolEntities context = new OnlineSchoolEntities();
        [Authorize]//(Roles="Students")]
        public ActionResult CoursePage(int id)
        {
            coursePageVM.index =
               (from crs in context.Segments
                from asd in context.InstructorCoures
                from inst in context.Instructors
                where (crs.InstructorCourseID == id && crs.InstructorCourseID == asd.InstructorCourseID && asd.InstructorID == inst.InstructorID)
                select new listofsegment()
                {
                    Description = crs.Description,
                    FullName = inst.FullName,
                    InstructorID = inst.InstructorID,
                    JobDescription = inst.JobDescription,
                    JobTitle = inst.JobTitle
                }).ToList();
            coursePageVM.InstructorName = coursePageVM.index[0].FullName;
            coursePageVM.JobTitle = coursePageVM.index[0].JobTitle;
            coursePageVM.JobDescription = coursePageVM.index[0].JobDescription;
            return View(coursePageVM);

            //var seg = context.Segments.Where(a => a.InstructorCourseID == id).ToList();
            //return View(seg);
        }
	}
}