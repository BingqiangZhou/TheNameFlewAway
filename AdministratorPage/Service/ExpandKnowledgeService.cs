using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class ExpandKnowledgeService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<ExpandKnowledge> GetAllExpandKnowledges()
        {
            return db.ExpandKnowledges.ToList();
        }

        public ExpandKnowledge GetExpandKnowledge(int? id)
        {
            return db.ExpandKnowledges.Find(id);
        }

        public bool AddExpandKnowledge(ExpandKnowledge expandKnowledge)
        {
            db.ExpandKnowledges.Add(expandKnowledge);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyExpandKnowledge(ExpandKnowledge expandKnowledge)
        {
            db.Entry(expandKnowledge).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveExpandKnowledge(int id)
        {
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            db.ExpandKnowledges.Remove(expandKnowledge);
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