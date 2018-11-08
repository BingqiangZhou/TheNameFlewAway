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
    public class AdvanceKnowledgesController : Controller
    {
        private TrainingEntities db = new TrainingEntities();

        // GET: AdvanceKnowledges
        public ActionResult Index()
        {
            return View(db.AdvanceKnowledges.ToList());
        }

        // GET: AdvanceKnowledges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            if (advanceKnowledge == null)
            {
                return HttpNotFound();
            }
            var resources = db.AdvanceKonwledgeAndResources.AsEnumerable().Join(db.Resources, p => p.resourceid, q => q.id,
                (p, q) => new {p, q}).Where(p => p.p.id == id).Select(p=>new Resource()
                {
                    id = p.p.resourceid,
                    name = p.q.name,
                    description = p.q.description,
                    address = p.q.address,
                }).ToList();
            ViewBag.Konwledge = resources;
            return View(advanceKnowledge);
        }

        // GET: AdvanceKnowledges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvanceKnowledges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,key,imageaddress,description,context")] AdvanceKnowledge advanceKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.AdvanceKnowledges.Add(advanceKnowledge);
                db.SaveChanges();
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
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            if (advanceKnowledge == null)
            {
                return HttpNotFound();
            }
            return View(advanceKnowledge);
        }

        // POST: AdvanceKnowledges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,key,imageaddress,description,context")] AdvanceKnowledge advanceKnowledge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advanceKnowledge).State = EntityState.Modified;
                db.SaveChanges();
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
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
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
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            db.AdvanceKnowledges.Remove(advanceKnowledge);
            db.SaveChanges();
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
            if (file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
            }
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                db.AdvanceKonwledgeAndResources.Add(
                    new AdvanceKonwledgeAndResource() {id=int.Parse(ak),resourceid=resource.id});
                db.SaveChanges();
                return RedirectToAction("Details/"+ak);
            }
            return View(resource);
        }

        public ActionResult DeleteKnowledge(int id,int resourceid)
        {
            AdvanceKonwledgeAndResource ak = new AdvanceKonwledgeAndResource()
            { id = id, resourceid = resourceid };
            if (ModelState.IsValid)
            {
                db.Resources.Remove(db.Resources.Find(resourceid));
                db.SaveChanges();
                db.AdvanceKonwledgeAndResources.Remove(db.AdvanceKonwledgeAndResources.Find(id, resourceid));
                db.SaveChanges();
            }
            return RedirectToAction("Details/" + id);
        }

        public ActionResult ConfirmEditKnowledge([Bind(Include = "id,name,description,address,typeid,time")] Resource resource,
            HttpPostedFileBase file, string ak)
        {
            var id = ak;
            if (file != null)
            {
                resource.address = file.FileName;
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
            }
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
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
            Resource resource = db.Resources.Find(resourceid);
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
