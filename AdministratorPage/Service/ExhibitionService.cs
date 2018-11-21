using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class ExhibitionService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<Exhibition> GetAllExhibitions()
        {
            return db.Exhibitions.ToList();
        }

        public Exhibition GetExhibition(int? id)
        {
            return db.Exhibitions.Find(id);
        }

        public bool AddExhibition(Exhibition exhibition)
        {
            db.Exhibitions.Add(exhibition);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyExhibition(Exhibition exhibition)
        {
            db.Entry(exhibition).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveExhibition(int id)
        {
            Exhibition expandKnowledge = db.Exhibitions.Find(id);
            db.Exhibitions.Remove(expandKnowledge);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}