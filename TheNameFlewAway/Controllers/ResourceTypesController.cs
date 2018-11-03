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
    /// 资源类型相关API
    /// </summary>
    public class ResourceTypesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有资源类型
        /// </summary>
        /// <returns>返回所有资源类型、数量以及操作标识</returns>
        [HttpPost]
        public ResourceTypeResponse.GetResourceTypes GetResourceTypes()
        {
            bool operate = false;
            if(db.ResourceTypes.Count() > 0)
            {
                operate = true;
            }
            return new ResourceTypeResponse.GetResourceTypes()
            { resourceTypes = db.ResourceTypes.ToList(), operate = operate };
        }

        /// <summary>
        /// 修改资源类型信息
        /// </summary>
        /// <param name="resourceType">资源类型对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyResourceType(ResourceType resourceType)
        {
            bool operate = false;
            if (ResourceTypeExists(resourceType.id))
            {
                db.Entry(resourceType).State = EntityState.Modified;
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
        /// 添加资源类型信息
        /// </summary>
        /// <param name="resourceType">资源类型对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddResourceType(ResourceType resourceType)
        {
            bool operate = false;
            if (!ResourceTypeExists(resourceType.id))
            {
                db.ResourceTypes.Add(resourceType);
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
        /// 删除资源类型信息
        /// </summary>
        /// <param name="id">资源类型id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteResourceType(int id)
        {
            bool operate = false;
            ResourceType resourceType = db.ResourceTypes.Find(id);
            if (resourceType != null)
            {
                db.ResourceTypes.Remove(resourceType);
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

        private bool ResourceTypeExists(int id)
        {
            return db.ResourceTypes.Count(e => e.id == id) > 0;
        }
    }
}