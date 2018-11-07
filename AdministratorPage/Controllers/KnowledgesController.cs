using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdministratorPage.Models;

namespace AdministratorPage.Controllers
{
    public class KnowledgesController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: Knowledges
        public ActionResult Index()
        {
            return View(db.Knowledges.ToList());
        }

        // GET: Knowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // GET: Knowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Knowledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,image,key,resourceAddress,description,context")] Knowledge knowledge,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    knowledge.resourceAddress = file.FileName;
                    string path = ConfigurationManager.AppSettings["Resource"];
                    var filePath = Server.MapPath(path);
                    file.SaveAs(Path.Combine(filePath, file.FileName));
                }
                db.Knowledges.Add(knowledge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knowledge);
        }

        // GET: Knowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // POST: Knowledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,image,key,resourceAddress,description,context")] Knowledge knowledge,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    knowledge.resourceAddress = file.FileName;
                    string path = ConfigurationManager.AppSettings["Resource"];
                    var filePath = Server.MapPath(path);
                    file.SaveAs(Path.Combine(filePath, file.FileName));
                }
                db.Entry(knowledge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knowledge);
        }

        // GET: Knowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // POST: Knowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);
            var path = ConfigurationManager.AppSettings["Resource"];
            var filePath = Server.MapPath(path);
            if (knowledge.resourceAddress != null && !knowledge.resourceAddress.StartsWith("http"))
            {
                System.IO.File.Delete(Path.Combine(filePath, knowledge.resourceAddress));
            }
            db.Knowledges.Remove(knowledge);
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
