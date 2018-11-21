using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class UploadRecordForTeacherService
    {
        private TrainingEntities db = new TrainingEntities();
        CustomService customService = new CustomService();

        public User GetTeacherInfo(int id)
        {
            User user = db.Users.Find(id);
            if (user != null && user.status == 1)
            {
                return user;
            }
            return null;
        }

        public List<Resource> GetTeacherUploadResource(int id)
        {
            var resources = db.Resources.AsEnumerable().Join(db.UploadRecordForTeachers, p => p.id, q => q.sourceId, (p, q) => new { p, q })
                .Where(p => p.q.userId == id).Select(p => new Resource()
                {
                    id = p.p.id,
                    description = p.p.description,
                    address = p.p.address,
                    name = p.p.name,
                    time = p.p.time,
                    typeid = p.p.typeid
                }).ToList();
            return resources;
        }

        public bool AddUploadRecordForTeachers(UploadRecordForTeacher uploadRecordForTeacher)
        {
            db.UploadRecordForTeachers.Add(uploadRecordForTeacher);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveUploadRecordForTeachers(int rid,int mid)
        {
            db.UploadRecordForTeachers.Remove(db.UploadRecordForTeachers.Find(rid, mid));
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