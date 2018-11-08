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
    public class ExhibitionsController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: Exhibitions
        public ActionResult Index()
        {
            ViewBag.ResourceAddress = ConfigurationManager.AppSettings["Resource"];
            ViewBag.TypeList = db.ExhibitionTypes.ToList();
            return View(db.Exhibitions.ToList());
        }

        // GET: Exhibitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public ActionResult Create()
        {
            List<SelectListItem> listBox = new List<SelectListItem>();
            foreach (var item in db.ExhibitionTypes.ToList())
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

        // POST: Exhibitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,description,showimage,coverimage,typeid,resourceaddress,name")] Exhibition exhibition, 
            HttpPostedFileBase file,HttpPostedFileBase picture)
        {
            string path = ConfigurationManager.AppSettings["Resource"];
            //var filePath = Server.MapPath(path);
            if (file != null)
            {
                file.SaveAs(Path.Combine(path, file.FileName));
                exhibition.resourceaddress = file.FileName;
            }
            if (picture != null)
            {
                string ExtName = Path.GetExtension(picture.FileName).ToLower();
                if (ExtName != ".jpg" && ExtName != ".jpeg" && ExtName != ".png" && ExtName != ".gif")
                {
                    return Content("图片格式不正确，只允许上传jpg,png,gif！" +
                        "<a href=#' onClick='javascript :history.back(-1);'>返回</a>");
                }
                picture.SaveAs(Path.Combine(path, picture.FileName));
                exhibition.showimage = picture.FileName;
            }

            if (ModelState.IsValid)
            {
                db.Exhibitions.Add(exhibition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibition);
        }

        // GET: Exhibitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> listBox = new List<SelectListItem>();
            foreach (var item in db.ExhibitionTypes.ToList())
            {
                var temp = new SelectListItem
                {
                    Value = item.id.ToString(),
                    Text = item.name + "(" + item.id + ")"
                };
                listBox.Add(temp);
            }
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,description,showimage,coverimage,typeid,resourceaddress,name")] Exhibition exhibition,
            HttpPostedFileBase file, HttpPostedFileBase picture)
        {
            string path = ConfigurationManager.AppSettings["Resource"];
            //var filePath = Server.MapPath(path);
            if (file != null)
            {
                file.SaveAs(Path.Combine(path, file.FileName));
                exhibition.resourceaddress = file.FileName;
            }
            if (picture != null)
            {
                string ExtName = Path.GetExtension(picture.FileName).ToLower();
                if (ExtName != ".jpg" && ExtName != ".jpeg" && ExtName != ".png" && ExtName != ".gif")
                {
                    return Content("图片格式不正确，只允许上传jpg,png,gif！" +
                        "<a href=#' onClick='javascript :history.back(-1);'>返回</a>");
                }
                picture.SaveAs(Path.Combine(path, picture.FileName));
                exhibition.showimage = picture.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(exhibition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.ResourceAddress = ConfigurationManager.AppSettings["Resource"];
            Exhibition exhibition = db.Exhibitions.Find(id);
            //var path = ConfigurationManager.AppSettings["Resource"];
            //var filePath = Server.MapPath(path);
            //if (exhibition.showimage != null && !exhibition.showimage.StartsWith("http"))
            //{
            //    System.IO.File.Delete(Path.Combine(filePath, exhibition.showimage));
            //}
            //if (exhibition.resourceaddress != null && !exhibition.resourceaddress.StartsWith("http"))
            //{
            //    System.IO.File.Delete(Path.Combine(filePath, exhibition.showimage));
            //}
            db.Exhibitions.Remove(exhibition);
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
