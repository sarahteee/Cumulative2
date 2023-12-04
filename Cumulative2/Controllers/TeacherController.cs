using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative2.Models;
using System.Diagnostics;

namespace Cumulative2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List?TeacherSearchKey={value}
        // Go to /Views/Teacher/List.cshtml
        // Browser opens a list teachers page
        public ActionResult List(string TeacherSearchKey)
        {
            //Check if the search key works
            Debug.WriteLine("I want to search for teachers with the key " + TeacherSearchKey);

            //pass teacher information to view
            //create instance of teacher data controller
            TeacherDataController Controller = new TeacherDataController();

            List<Teacher> Teachers = Controller.ListTeachers(TeacherSearchKey);

            //pass teacher information to /views/teacher/list
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        //Route to /Views/Teachers/Show.cshtml
        public ActionResult Show(int id)
        {
            TeacherDataController Controller = new TeacherDataController();

            Teacher SelectedTeacher = Controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        //GET: /Teacher/New
        //Route to /Views/Teacher/New.cshtml

        public ActionResult New()
        { 
            return View(); 
        }

        //POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(Teacher NewTeacher)
        {
            //Get the submitted teacher info
            Debug.WriteLine("The following teacher information has been received: " + NewTeacher.TeacherFName);

            //add the submitted teacher info to the database
            TeacherDataController Controller = new TeacherDataController();

            Controller.AddTeacher(NewTeacher);

         

            //return to original teacher list
            return RedirectToAction("List");
        }

        //GET: /Teacher/DeleteConfirm/{teacherid}
        public ActionResult DeleteConfirm(int id) 
        {
            TeacherDataController Controller = new TeacherDataController();

            Teacher SelectedTeacher = Controller.FindTeacher(id);

          
            return View(SelectedTeacher);
        }

        //POST: /Teacher/Delete/{teacherid}
        [HttpPost]

        public ActionResult Delete(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

    }
}