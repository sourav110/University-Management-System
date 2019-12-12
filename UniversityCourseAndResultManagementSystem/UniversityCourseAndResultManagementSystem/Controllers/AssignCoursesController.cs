using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class AssignCoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: AssignCourses
        public async Task<ActionResult> Index()
        {
            var assignCourses = db.AssignCourses.Include(a => a.Course);
            return View(await assignCourses.ToListAsync());
        }

        // GET: AssignCourses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // GET: AssignCourses/Create
        public ActionResult Create()
        {
            ViewBag.Departments = db.Departments.ToList();
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            return View();
        }

        // POST: AssignCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssignId,DepartmentId,TeacherId,CreditToBeTaken,RemainingCredit,CourseId,CourseName,Credit")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                db.AssignCourses.Add(assignCourse);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = db.Departments.ToList();
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assignCourse.CourseId);
            return View(assignCourse);
        }

        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            var teachers = db.Teachers.Where(t => t.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        // GET: AssignCourses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assignCourse.CourseId);
            return View(assignCourse);
        }

        // POST: AssignCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AssignId,DepartmentId,TeacherId,CreditToBeTaken,RemainingCredit,CourseId,CourseName,Credit")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignCourse).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assignCourse.CourseId);
            return View(assignCourse);
        }

        // GET: AssignCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // POST: AssignCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            db.AssignCourses.Remove(assignCourse);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
