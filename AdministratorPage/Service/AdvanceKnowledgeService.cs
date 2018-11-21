using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class AdvanceKnowledgeService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<AdvanceKnowledge> GetAllAdvanceKnowledges()
        {
            return db.AdvanceKnowledges.ToList();
        }

        public AdvanceKnowledge GetAdvanceKnowledge(int? id)
        {
            return db.AdvanceKnowledges.Find(id);
        }

        public List<Resource> GetRelevantResource(int? id)
        {
            return db.AdvanceKonwledgeAndResources.AsEnumerable().Join(db.Resources, p => p.resourceid, q => q.id,
                (p, q) => new { p, q }).Where(p => p.p.id == id).Select(p => new Resource()
                {
                    id = p.p.resourceid,
                    name = p.q.name,
                    description = p.q.description,
                    address = p.q.address,
                }).ToList();
        }

        public bool AddRelevantResource(Resource resource ,int id)
        {
            db.Resources.Add(resource);
            int count = db.SaveChanges();
            if (count == 0)
            {
                return false;
            }
            db.AdvanceKonwledgeAndResources.Add(
                new AdvanceKonwledgeAndResource() { id = id, resourceid = resource.id });
            count = db.SaveChanges();
            if (count == 0)
            {
                return false;
            }
            return true;
        }
        public bool RemoveRelevantResource(int resourceid, int id)
        {
            db.Resources.Remove(db.Resources.Find(resourceid));
            int count = db.SaveChanges();
            if (count == 0)
            {
                return false;
            }
            db.AdvanceKonwledgeAndResources.Remove(db.AdvanceKonwledgeAndResources.Find(id, resourceid));
            count = db.SaveChanges();
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public bool AddAdvanceKnowledge(AdvanceKnowledge advanceKnowledge)
        {
            db.AdvanceKnowledges.Add(advanceKnowledge);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyAdvanceKnowledge(AdvanceKnowledge advanceKnowledge)
        {
            db.Entry(advanceKnowledge).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveAdvanceKnowledge(int id)
        {
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            db.AdvanceKnowledges.Remove(advanceKnowledge);
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