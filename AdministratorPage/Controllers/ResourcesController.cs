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
    public class ResourcesController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: Resources
        public ActionResult Index()
        {
            ViewBag.TypeList = db.ResourceTypes.ToList();
            return View(db.Resources.Where(
                    delegate(Resource resource)
                    {
                        if(resource.typeid.HasValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                ));
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            List<SelectListItem> listBox = new List<SelectListItem>();
            foreach (var item in db.ResourceTypes.ToList())
            {
                var temp = new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.name + "(" + item.id + ")"
                };
                listBox.Add(temp);
            }
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text"); ;
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,HttpPostedFileBase file)
        {
            if(file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
                resource.time = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> listBox = new List<SelectListItem>();
            foreach (var item in db.ResourceTypes.ToList())
            {
                var temp = new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.name + "(" + item.id + ")"
                };
                listBox.Add(temp);
            }
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text"); ;
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,HttpPostedFileBase file)
        {
            if (file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
                resource.time = DateTime.Now;
            }
            else
            {
                var re = db.Resources.AsNoTracking().Where(p => p.id == resource.id).FirstOrDefault();
                resource.time = re.time ?? DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            //var path = ConfigurationManager.AppSettings["Resource"];
            //var filePath = Server.MapPath(path);
            //if (resource.address != null && !resource.address.StartsWith("http"))
            //{
            //    System.IO.File.Delete(Path.Combine(filePath, resource.address));
            //}
            db.Resources.Remove(resource);
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
