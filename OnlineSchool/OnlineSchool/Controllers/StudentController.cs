using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSchool.Models.BusinesssLayer;
using OnlineSchool.Models.DataBaseModel;
using OnlineSchool.Models.ViewModel;
using System.IO;

namespace OnlineSchool.Controllers
{
    [Authorize(Roles="Students")]
    public class StudentController : Controller
    {
        // GET: Student
        StudentBL studentBL = new StudentBL();
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentDetailsVM model = new StudentDetailsVM();
            model.countries = studentBL.GetAllCountries();
            Student std = studentBL.GetStudentByID(id);
            model.CountryID = std.CountryID;
            model.FullName = std.FullName;
            model.StudentID = std.StudentID;
            model.Picture = std.Picture;
            model.RegisterationDate = std.RegisterationDate;

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(StudentDetailsVM StudentVM, HttpPostedFileBase uploadimage)
        {
            string path = Path.Combine(Server.MapPath("~/Images"), uploadimage.FileName);
            uploadimage.SaveAs(path);

            //InstructorBL instructorBL;
            Student std = new Student();
            std.StudentID = StudentVM.StudentID;
            std.CountryID = StudentVM.CountryID;
            std.FullName = StudentVM.FullName;
            std.Picture = StudentVM.Picture;

            std.Picture = uploadimage.FileName;
            if (ModelState.IsValid)
            {
                //instructorBL = new InstructorBL();
                bool chk = studentBL.UpdateStudent(std);
                if (chk)
                    return RedirectToAction("Edit");
                else
                    return View(StudentVM);
            }
            else
                return View(StudentVM);
        }
    }
}