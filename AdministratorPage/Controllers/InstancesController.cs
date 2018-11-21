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
    public class InstancesController : Controller
    {
        InstanceService instanceService = new InstanceService();
        CustomService customService = new CustomService();

        // GET: Instances
        public ActionResult Index()
        {
            return View(instanceService.GetAllInstances());
        }

        // GET: Instances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instance instance = instanceService.GetInstance(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,resourceAddress,key,image,title,code,context,result")] Instance instance,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (customService.SaveFile(file))
                {
                    instance.resourceAddress = file.FileName;
                }
                instanceService.AddInstance(instance);
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
            Instance instance = instanceService.GetInstance(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View(instance);
        }

        // POST: Instances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,resourceAddress,key,image,title,code,context,result")] Instance instance,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (customService.SaveFile(file))
                {
                    instance.resourceAddress = file.FileName;
                }
                instanceService.ModifyInstance(instance);
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
            Instance instance = instanceService.GetInstance(id);
            
            //var filePath = Server.MapPath(path);
            if (instance.resourceAddress != null && !instance.resourceAddress.StartsWith("http"))
            {
                customService.RemoveFile(instance.resourceAddress);
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
            instanceService.RemoveInstance(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customService.Dispose();
                instanceService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
