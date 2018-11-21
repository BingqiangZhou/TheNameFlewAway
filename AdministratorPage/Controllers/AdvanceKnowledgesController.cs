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
    public class AdvanceKnowledgesController : Controller
    {
        AdvanceKnowledgeService advanceKnowledgeService = new AdvanceKnowledgeService();
        CustomService customService = new CustomService();
        ResourceService resourceService = new ResourceService();

        // GET: AdvanceKnowledges
        public ActionResult Index()
        {
            return View(advanceKnowledgeService.GetAllAdvanceKnowledges());
        }

        // GET: AdvanceKnowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceKnowledge advanceKnowledge = advanceKnowledgeService.GetAdvanceKnowledge(id);
            if (advanceKnowledge == null)
            {
                return HttpNotFound();
            }
            var resources = advanceKnowledgeService.GetRelevantResource(id);
            ViewBag.Konwledge = resources;
            return View(advanceKnowledge);
        }

        // GET: AdvanceKnowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvanceKnowledges/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,key,imageaddress,description,context")] AdvanceKnowledge advanceKnowledge)
        {
            if (ModelState.IsValid)
            {
                advanceKnowledgeService.AddAdvanceKnowledge(advanceKnowledge);
                return RedirectToAction("Index");
            }

            return View(advanceKnowledge);
        }

        // GET: AdvanceKnowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceKnowledge advanceKnowledge = advanceKnowledgeService.GetAdvanceKnowledge(id);
            if (advanceKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(advanceKnowledge);
        }

        // POST: AdvanceKnowledges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,key,imageaddress,description,context")] AdvanceKnowledge advanceKnowledge)
        {
            if (ModelState.IsValid)
            {
                advanceKnowledgeService.ModifyAdvanceKnowledge(advanceKnowledge);
                return RedirectToAction("Index");
            }
            return View(advanceKnowledge);
        }

        // GET: AdvanceKnowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceKnowledge advanceKnowledge = advanceKnowledgeService.GetAdvanceKnowledge(id);
            if (advanceKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(advanceKnowledge);
        }

        // POST: AdvanceKnowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            advanceKnowledgeService.RemoveAdvanceKnowledge(id);
            return RedirectToAction("Index");
        }
        public ActionResult AddKnowLedge(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmAddKnowledge([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,
            HttpPostedFileBase file,string ak)
        {
            var id = ak;
            if (customService.SaveFile(file))
            {
                resource.address = file.FileName;
            }
            if (ModelState.IsValid)
            {
                advanceKnowledgeService.AddRelevantResource(resource, int.Parse(ak));
                return RedirectToAction("Details/"+ak);
            }
            return View(resource);
        }

        public ActionResult DeleteKnowledge(int id,int resourceid)
        {
            if (ModelState.IsValid)
            {
                advanceKnowledgeService.RemoveRelevantResource(resourceid, id);
            }
            return RedirectToAction("Details/" + id);
        }

        public ActionResult ConfirmEditKnowledge([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,
            HttpPostedFileBase file, string ak)
        {
            var id = ak;
            if (customService.SaveFile(file))
            {
                resource.address = file.FileName;
            }
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Details/"+ak);
            }
            return View(resource);
        }
        public ActionResult EditKnowledge(int id,int resourceid)
         {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = resourceService.GetResource(resourceid);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customService.Dispose();
                advanceKnowledgeService.Dispose();
                resourceService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
