using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPage.Service
{
    public class CustomService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<ResourceType> GetAllResourceTypes()
        {
            return db.ResourceTypes.ToList();
        }

        public List<ExhibitionType> GetAllExhibitionTypes()
        {
            return db.ExhibitionTypes.ToList();
        }

        public List<SelectListItem> GetResourceTypesListItem()
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
            return listBox;
        }

        public List<SelectListItem> GetExhibitionTypesListItem()
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
            return listBox;
        }

        public bool SaveFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string path = ConfigurationManager.AppSettings["Resource"];
                //var filePath = Server.MapPath(path);
                file.SaveAs(Path.Combine(path, file.FileName));
                return true;
            }
            return false;
        }

        public void RemoveFile(string filePath)
        {
            var path = ConfigurationManager.AppSettings["Resource"];
            System.IO.File.Delete(Path.Combine(path, filePath));
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}