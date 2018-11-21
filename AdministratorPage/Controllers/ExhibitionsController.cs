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
    public class ExhibitionsController : Controller
    {
        ExhibitionService exhibitionService = new ExhibitionService();
        CustomService customService = new CustomService();

        // GET: Exhibitions
        public ActionResult Index()
        {
            ViewBag.ResourceAddress = "https://bingqiangzhou.cn/Training/AppResources/";
            ViewBag.TypeList = customService.GetAllExhibitionTypes();
            return View(exhibitionService.GetAllExhibitions());
        }

        // GET: Exhibitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = exhibitionService.GetExhibition(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: Exhibitions/Create
        public ActionResult Create()
        {
            List<SelectListItem> listBox = customService.GetExhibitionTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text"); ;
            return View();
        }

        // POST: Exhibitions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,author,description,showimage,coverimage,typeid,resourceaddress,name")] Exhibition exhibition, 
            HttpPostedFileBase file,HttpPostedFileBase picture)
        {
            //var filePath = Server.MapPath(path);
            if (customService.SaveFile(file))
            {
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
                customService.SaveFile(picture);
                exhibition.showimage = picture.FileName;
            }

            if (ModelState.IsValid)
            {
                exhibitionService.AddExhibition(exhibition);
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
            Exhibition exhibition = exhibitionService.GetExhibition(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> listBox = customService.GetExhibitionTypesListItem();
            ViewBag.TypeList = new SelectList(listBox, "Value", "Text");
            return View(exhibition);
        }

        // POST: Exhibitions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,author,description,showimage,coverimage,typeid,resourceaddress,name")] Exhibition exhibition,
            HttpPostedFileBase file, HttpPostedFileBase picture)
        {
            if (customService.SaveFile(file))
            {
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
                customService.SaveFile(picture);
                exhibition.showimage = picture.FileName;
            }
            if (ModelState.IsValid)
            {
                exhibitionService.ModifyExhibition(exhibition);
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
            Exhibition exhibition = exhibitionService.GetExhibition(id);
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
            exhibitionService.RemoveExhibition(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                customService.Dispose();
                exhibitionService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
