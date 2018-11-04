using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TheNameFlewAway.Models;
using TheNameFlewAway.ResponseModel;

namespace TheNameFlewAway.Controllers
{
    /// <summary>
    /// 上传记录相关API
    /// </summary>
    public class UploadRecordForTeachersController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 通过用户（教师）ID获取上传记录
        /// </summary>
        /// <param name="id">用户（教师）id</param>
        /// <returns>返回上传记录信息、记录数量以及操作标识</returns>
        [HttpPost]
        public UploadRecordForTeacherResponse.GetUploadRecordByTeacherId GetUploadRecordByTeacherId(int id)
        {
            bool operate = false;
            IEnumerable<UploadRecordForTeacher> uploadRecordForTeachers = db.UploadRecordForTeachers.Where(
                    delegate (UploadRecordForTeacher uploadRecordForTeacher)
                    {
                        if (uploadRecordForTeacher.userId == id)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );
            if (uploadRecordForTeachers.Count() > 0) 
            {
                operate = true;
            }
            return new UploadRecordForTeacherResponse.GetUploadRecordByTeacherId()
            {
                uploadRecordForTeachers = uploadRecordForTeachers.ToList(),
                operate = operate
            };
        }

        /// <summary>
        /// 修改上传记录
        /// </summary>
        /// <param name="uploadRecordForTeacher">上传记录对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyUploadRecordForTeacher(UploadRecordForTeacher uploadRecordForTeacher)
        {
            bool operate = false;
            if (UploadRecordForTeacherExists(uploadRecordForTeacher.sourceId))
            {
                db.Entry(uploadRecordForTeacher).State = EntityState.Modified;
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 添加上传记录
        /// </summary>
        /// <param name="uploadRecordForTeacher">上传记录对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddUploadRecordForTeacher(UploadRecordForTeacher uploadRecordForTeacher)
        {
            bool operate = false;
            if (!UploadRecordForTeacherExists(uploadRecordForTeacher.sourceId))
            {
                db.UploadRecordForTeachers.Add(uploadRecordForTeacher);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 删除上传记录
        /// </summary>
        /// <param name="uploadRecordForTeacher">上传记录对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteUploadRecordForTeacher(UploadRecordForTeacher uploadRecordForTeacher)
        {
            bool operate = false;
            UploadRecordForTeacher uploadRecord = db.UploadRecordForTeachers.Find(uploadRecordForTeacher.userId, uploadRecordForTeacher.sourceId);
            if (uploadRecordForTeacher != null)
            {
                db.UploadRecordForTeachers.Remove(uploadRecord);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UploadRecordForTeacherExists(int id)
        {
            return db.UploadRecordForTeachers.Count(e => e.sourceId == id) > 0;
        }
    }
}