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
    public class InstancesController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: Instances
        public ActionResult Index()
        {
            return View(db.Instances.ToList());
        }

        // GET: Instances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // GET: Instances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,resourceAddress,key,image,title,code,context,result")] Instance instance,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    instance.resourceAddress = file.FileName;
                    string path = ConfigurationManager.AppSettings["Resource"];
                    var filePath = Server.MapPath(path);
                    file.SaveAs(Path.Combine(filePath, file.FileName));
                }
                db.Instances.Add(instance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instance);
        }

        // GET: Instances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // POST: Instances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,resourceAddress,key,image,title,code,context,result")] Instance instance,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    instance.resourceAddress = file.FileName;
                    string path = ConfigurationManager.AppSettings["Resource"];
                    var filePath = Server.MapPath(path);
                    file.SaveAs(Path.Combine(filePath, file.FileName));
                }
                db.Entry(instance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instance);
        }

        // GET: Instances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = db.Instances.Find(id);
            var path = ConfigurationManager.AppSettings["Resource"];
            var filePath = Server.MapPath(path);
            if (instance.resourceAddress != null && !instance.resourceAddress.StartsWith("http"))
            {
                System.IO.File.Delete(Path.Combine(filePath, instance.resourceAddress));
            }
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // POST: Instances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instance instance = db.Instances.Find(id);
            db.Instances.Remove(instance);
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
