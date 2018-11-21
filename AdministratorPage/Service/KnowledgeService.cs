using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class KnowledgeService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<Knowledge> GetAllKnowledge()
        {
            return db.Knowledges.ToList();
        }

        public Knowledge GetKnowledge(int? id)
        {
            return db.Knowledges.Find(id);
        }

        public bool AddKnowLedge(Knowledge knowledge)
        {
            db.Knowledges.Add(knowledge);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyKnowledge(Knowledge knowledge)
        {
            db.Entry(knowledge).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveKnowledge(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);
            db.Knowledges.Remove(knowledge);
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