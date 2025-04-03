using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsApp;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
        private Entities db = new Entities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.tblStudents.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Email,EnrollmentDate")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(tblStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStudent);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Email,EnrollmentDate")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStudent);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            db.tblStudents.Remove(tblStudent);
            db.SaveChanges();
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
