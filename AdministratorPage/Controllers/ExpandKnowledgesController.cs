using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdministratorPage.Models;
using AdministratorPage.Service;

namespace AdministratorPage.Controllers
{
    public class ExpandKnowledgesController : Controller
    {
        ExpandKnowledgeService expandKnowledgeService = new ExpandKnowledgeService();

        // GET: ExpandKnowledges
        public ActionResult Index()
        {
            return View(expandKnowledgeService.GetAllExpandKnowledges());
        }

        // GET: ExpandKnowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = expandKnowledgeService.GetExpandKnowledge(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpandKnowledges/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,key,description,url")] ExpandKnowledge expandKnowledge)
        {
            if (ModelState.IsValid)
            {
                expandKnowledgeService.AddExpandKnowledge(expandKnowledge);
                return RedirectToAction("Index");
            }

            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = expandKnowledgeService.GetExpandKnowledge(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // POST: ExpandKnowledges/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,key,description,url")] ExpandKnowledge expandKnowledge)
        {
            if (ModelState.IsValid)
            {
                expandKnowledgeService.ModifyExpandKnowledge(expandKnowledge);
                return RedirectToAction("Index");
            }
            return View(expandKnowledge);
        }

        // GET: ExpandKnowledges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpandKnowledge expandKnowledge = expandKnowledgeService.GetExpandKnowledge(id);
            if (expandKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(expandKnowledge);
        }

        // POST: ExpandKnowledges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            expandKnowledgeService.RemoveExpandKnowledge(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                expandKnowledgeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
