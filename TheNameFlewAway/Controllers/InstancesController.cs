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
    /// 实例教程相关API
    /// </summary>
    public class InstancesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有实例信息
        /// </summary>
        /// <returns>返回实例信息列表以及操作结果标识</returns>
        [HttpPost]
        public InstanceResponse.GetAllInstances GetAllInstances()
        {
            bool operate = false;
            List<MainResponse.DataMap> infos = db.Instances.Select(p => new { p.id, p.key }).AsEnumerable()
                .Select(p => new MainResponse.DataMap(p.id, p.key)).ToList();
            if(infos != null && infos.Count > 0)
            {
                operate = true;
            }
            return new InstanceResponse.GetAllInstances()
            { instances = infos, operate = operate };
        }

        /// <summary>
        /// 通过id获取实例信息
        /// </summary>
        /// <param name="id">实例id</param>
        /// <returns>返回实例信息列表以及操作结果标识</returns>
        [HttpPost]
        public InstanceResponse.GetInstance GetInstance(int id)
        {
            bool operate = true;
            Instance instance = db.Instances.Find(id);
            if (instance == null)
            {
                operate = false;
            }
            return new InstanceResponse.GetInstance()
            { instance = instance, operate = operate };
        }

        /// <summary>
        /// 修改实例
        /// </summary>
        /// <param name="instance">实例对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        public MainResponse.DefaultResponse ModifyInstance(Instance instance)
        {
            bool operate = false;
            if (InstanceExists(instance.id))
            {
                db.Entry(instance).State = EntityState.Modified;
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
        /// 添加实例
        /// </summary>
        /// <param name="instance">实例对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddInstance(Instance instance)
        {
            bool operate = false;
            if (InstanceExists(instance.id))
            {
                db.Entry(instance).State = EntityState.Modified;
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
        /// 删除实例
        /// </summary>
        /// <param name="id">实例id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteInstance(int id)
        {
            bool operate = false;
            Instance instance = db.Instances.Find(id);
            if (instance != null)
            {
                db.Instances.Remove(instance);
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

        private bool InstanceExists(int id)
        {
            return db.Instances.Count(e => e.id == id) > 0;
        }
    }
}