using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class ClassroomController : Controller
    {
        ProjectDbContext db = new ProjectDbContext();
        // GET: Classroom
        public ActionResult AllocateClassroom()
        {

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.Courses = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo");
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayName");
            return View();
        }

        public JsonResult GetCoursesByDeptId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }
    }
}