using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class InstanceService
    {
        private TrainingEntities db = new TrainingEntities();

        public List<Instance> GetAllInstances()
        {
            return db.Instances.ToList();
        }

        public Instance GetInstance(int? id)
        {
            return db.Instances.Find(id);
        }

        public bool AddInstance(Instance instance)
        {
            db.Instances.Add(instance);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool ModifyInstance(Instance instance)
        {
            db.Entry(instance).State = EntityState.Modified;
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveInstance(int id)
        {
            Instance instance = db.Instances.Find(id);
            db.Instances.Remove(instance);
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