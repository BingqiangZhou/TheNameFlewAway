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
using AdministratorPage.Service;

namespace AdministratorPage.Controllers
{
    public class UploadRecordForTeacherController : Controller
    {
        UploadRecordForTeacherService uploadRecordForTeacherService = new UploadRecordForTeacherService();
        CustomService customService = new CustomService();
        ResourceService resourceService = new ResourceService();
        // GET: UploadRecordForTeacher
        public ActionResult Index(int id)
        {
            User user = uploadRecordForTeacherService.GetTeacherInfo(id);
            if (user != null)
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
            ViewBag.TypeList = customService.GetAllResourceTypes();
            var resources = uploadRecordForTeacherService.GetTeacherUploadResource(id);
            return View(resources);
        }

        // GET: UploadRecordForTeacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = resourceService.GetResource(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: UploadRecordForTeacher/Create
        public ActionResult Create()
        {
            List<SelectListItem> listBox = customService.GetResourceTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            return View();
        }

        // POST: UploadRecordForTeacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,address,typeid,time")] Resource resource, HttpPostedFileBase file)
        {
            if (customService.SaveFile(file))
            {
                resource.address = file.FileName;
            }
            if (ModelState.IsValid)
            {
                resource.time = DateTime.Now;
                resourceService.AddResource(resource);
                var id = Request.Cookies["id"].Value.ToString();
                uploadRecordForTeacherService.AddUploadRecordForTeachers(
                    new UploadRecordForTeacher() { sourceId = resource.id, userId = int.Parse(id) });
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
            Resource resource = resourceService.GetResource(id);
            //Request.Cookies["id"].Value = id.ToString();
            List<SelectListItem> listBox = customService.GetResourceTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: UploadRecordForTeacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,address,typeid,time")] Resource resource, HttpPostedFileBase file)
        {
            if (customService.SaveFile(file))
            {
                resource.time = DateTime.Now;
                resource.address = file.FileName;
            }
            else
            {
                var re = resourceService.GetResource(resource.id);
                //db.Resources.AsNoTracking().Where(p => p.id == resource.id).FirstOrDefault()
                resource.time = re.time??DateTime.Now;
             //   System.Diagnostics.Debug.Write(resource.time);
            }
            if (ModelState.IsValid)
            {
                resourceService.ModifyResource(resource);
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
            Resource resource = resourceService.GetResource(id);
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
            resourceService.RemoveResource(id);
            var mid = Request.Cookies["id"].Value.ToString();
            uploadRecordForTeacherService.RemoveUploadRecordForTeachers(id, int.Parse(mid));
            return RedirectToAction("Index/"+mid);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customService.Dispose();
                uploadRecordForTeacherService.Dispose();
                resourceService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
