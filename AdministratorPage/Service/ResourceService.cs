using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class ResourceService
    {
        private TrainingEntities db = new TrainingEntities();

        public Resource GetResource(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.Resources.AsNoTracking().Where(p=>p.id == id).First();
        }

        public List<Resource> GetAllResources()
        {
            return db.Resources.Where(
                    delegate (Resource resource)
                    {
                        if (resource.typeid.HasValue)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                ).ToList();
        }

        public bool AddResource(Resource resource)
        {
            db.Resources.Add(resource);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyResource(Resource resource)
        {
            db.Entry(resource).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveResource(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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