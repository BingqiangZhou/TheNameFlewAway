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
    public class UploadRecordForTeacherController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: UploadRecordForTeacher
        public ActionResult Index(int id)
        {
            User user= db.Users.Find(id);
            if (user != null && user.status == 1)
            {
                Response.Cookies["id"].Value = user.id.ToString();
                Response.Cookies["id"].Expires = DateTime.Now.AddHours(2);
                Response.Cookies["name"].Value = user.name;
                Response.Cookies["name"].Expires = DateTime.Now.AddHours(2);
            }
            else
            {
                return Content("假老师！");
            }
            var resources = db.Resources.AsEnumerable().Join(db.UploadRecordForTeachers, p => p.id, q => q.sourceId, (p, q) => new { p, q })
                .Where(p => p.q.userId == id).Select(p => new Resource()
                {
                    id = p.p.id,
                    description = p.p.description,
                    address = p.p.address,
                    name = p.p.name,
                    time = p.p.time,
                    typeid = p.p.typeid
                }).ToList();
            ViewBag.TypeList = db.ResourceTypes.ToList();
            return View(resources);
        }

        // GET: UploadRecordForTeacher/Details/5
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

        // GET: UploadRecordForTeacher/Create
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
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            return View();
        }

        // POST: UploadRecordForTeacher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,address,typeid,time")] Resource resource, HttpPostedFileBase file)
        {
            if (file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
            }
            if (ModelState.IsValid)
            {
                resource.time = DateTime.Now;
                db.Resources.Add(resource);
                db.SaveChanges();
                var id = Request.Cookies["id"].Value.ToString();
                db.UploadRecordForTeachers.Add(new UploadRecordForTeacher() { sourceId = resource.id, userId = int.Parse(id) });
                db.SaveChanges();
                return RedirectToAction("Index/"+id);
            }
            return View(resource);
        }

        // GET: UploadRecordForTeacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
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
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: UploadRecordForTeacher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,address,typeid,time")] Resource resource, HttpPostedFileBase file)
        {
            if (file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
                resource.time = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                var id = Request.Cookies["id"].Value.ToString();
                return RedirectToAction("Index/"+id);
            }
            return View(resource);
        }

        // GET: UploadRecordForTeacher/Delete/5
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

        // POST: UploadRecordForTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
            db.SaveChanges();
            var mid = Request.Cookies["id"].Value.ToString();
            db.UploadRecordForTeachers.Remove(db.UploadRecordForTeachers.Find(id, int.Parse(mid)));
            return RedirectToAction("Index/"+mid);
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
