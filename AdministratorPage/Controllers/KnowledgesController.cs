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
    public class KnowledgesController : Controller
    {
        KnowledgeService knowledgeService = new KnowledgeService();
        CustomService customService = new CustomService();
        // GET: Knowledges
        public ActionResult Index()
        {
            return View(knowledgeService.GetAllKnowledge());
        }

        // GET: Knowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knowledge knowledge = knowledgeService.GetKnowledge(id);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,image,key,resourceAddress,description,context")] Knowledge knowledge,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (customService.SaveFile(file))
                {
                    knowledge.resourceAddress = file.FileName;
                }
                knowledgeService.AddKnowLedge(knowledge);
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
            Knowledge knowledge = knowledgeService.GetKnowledge(id);
            if (knowledge == null)
            {
                return HttpNotFound();
            }
            return View(knowledge);
        }

        // POST: Knowledges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,image,key,resourceAddress,description,context")] Knowledge knowledge,
            HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (customService.SaveFile(file))
                {
                    knowledge.resourceAddress = file.FileName;
                }
                knowledgeService.ModifyKnowledge(knowledge);
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
            Knowledge knowledge = knowledgeService.GetKnowledge(id);
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
            knowledgeService.RemoveKnowledge(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                knowledgeService.Dispose();
                customService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
