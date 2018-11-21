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
    public class ResourcesController : Controller
    {
        CustomService customService = new CustomService();
        ResourceService resourceService = new ResourceService();

        // GET: Resources
        public ActionResult Index()
        {
            ViewBag.TypeList = customService.GetAllResourceTypes();
            return View(resourceService.GetAllResources());
        }

        // GET: Resources/Details/5
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

        // GET: Resources/Create
        public ActionResult Create()
        {
            List<SelectListItem> listBox = customService.GetResourceTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text"); ;
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,HttpPostedFileBase file)
        {
            if(customService.SaveFile(file))
            {
                resource.address = file.FileName;
                resource.time = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                resourceService.AddResource(resource);
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
            Resource resource = resourceService.GetResource(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> listBox = customService.GetResourceTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text"); ;
            return View(resource);
        }

        // POST: Resources/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,HttpPostedFileBase file)
        {
            if (customService.SaveFile(file))
            {
                resource.address = file.FileName;
                resource.time = DateTime.Now;
            }
            else
            {
                var re = resourceService.GetResource(resource.id);
                resource.time = re.time ?? DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                resourceService.ModifyResource(resource);
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
            Resource resource = resourceService.GetResource(id);
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
            resourceService.RemoveResource(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customService.Dispose();
                resourceService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
