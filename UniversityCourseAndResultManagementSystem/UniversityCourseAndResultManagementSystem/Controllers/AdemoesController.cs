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
    public class AdemoesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Ademoes
        public async Task<ActionResult> Index()
        {
            var ademos = db.Ademos.Include(a => a.Course).Include(a => a.Department);
            return View(await ademos.ToListAsync());
        }

        // GET: Ademoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ademo ademo = await db.Ademos.FindAsync(id);
            if (ademo == null)
            {
                return HttpNotFound();
            }
            return View(ademo);
        }

        // GET: Ademoes/Create
        public ActionResult Create()
        {
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

        // POST: Ademoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AdemoId,DepartmentId,CourseId,CourseName,Credit")] Ademo ademo)
        {
            if (ModelState.IsValid)
            {
                db.Ademos.Add(ademo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", ademo.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", ademo.DepartmentId);
            return View(ademo);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        public JsonResult GetCourseByCourseId(int courseId)
        {
            var course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
            return Json(course);
        }


        // GET: Ademoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ademo ademo = await db.Ademos.FindAsync(id);
            if (ademo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", ademo.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", ademo.DepartmentId);
            return View(ademo);
        }

        // POST: Ademoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AdemoId,DepartmentId,CourseId,CourseName,Credit")] Ademo ademo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ademo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", ademo.CourseId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", ademo.DepartmentId);
            return View(ademo);
        }

        // GET: Ademoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ademo ademo = await db.Ademos.FindAsync(id);
            if (ademo == null)
            {
                return HttpNotFound();
            }
            return View(ademo);
        }

        // POST: Ademoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ademo ademo = await db.Ademos.FindAsync(id);
            db.Ademos.Remove(ademo);
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
