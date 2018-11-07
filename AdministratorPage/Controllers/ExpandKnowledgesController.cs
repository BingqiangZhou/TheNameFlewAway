using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdministratorPage.Models;

namespace AdministratorPage.Controllers
{
    public class ExpandKnowledgesController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: ExpandKnowledges
        public ActionResult Index()
        {
            return View(db.ExpandKnowledges.ToList());
        }

        // GET: ExpandKnowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpandKnowledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,key,description,url")] ExpandKnowledge expandKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.ExpandKnowledges.Add(expandKnowledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // POST: ExpandKnowledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,key,description,url")] ExpandKnowledge expandKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expandKnowledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // POST: ExpandKnowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            db.ExpandKnowledges.Remove(expandKnowledge);
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
