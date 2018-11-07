using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TheNameFlewAway.Models;
using TheNameFlewAway.RequestModel;
using TheNameFlewAway.ResponseModel;

namespace TheNameFlewAway.Controllers
{
    /// <summary>
    /// 资源相关API
    /// </summary>
    public class ResourcesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();
        //每页数据数
        private int dataEveryPage = int.Parse(ConfigurationManager.AppSettings["EveryPageDataCount"]);
        //资源路径
        private string resourcePath = ConfigurationManager.AppSettings["ResourcePath"];

        /// <summary>
        /// 通过资源类型id获取对应类别的资源
        /// </summary>
        /// <param name="parameters">获取资源请求参数对象</param>
        /// <returns>返回资源列表、资源数量以及操作比标识</returns>
        [HttpPost]
        public ResourceResponse.GetResources GetResources(ResourceRequest.GetResourcesRequest parameters)
        {
            int typeId = parameters.typeId;
            int page = parameters.page;
            if(page < 1)
            {
                page = 1;
            }
            bool operate = false;
            IEnumerable<Resource> resources = db.Resources.Where(
                    delegate (Resource resource)
                    {
                        if (resource.typeid == typeId)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                ).Skip((page - 1) * dataEveryPage - 1).Take(dataEveryPage);
            if (resources.Count() > 0)
            {
                operate = true;
            }
            return new ResourceResponse.GetResources()
            { resources = resources.ToList(), operate = operate };
        }

        /// <summary>
        /// 修改资源信息
        /// </summary>
        /// <param name="resource">资源对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyResource(Resource resource)
        {
            bool operate = false;
            if (ResourceExists(resource.id))
            {
                db.Entry(resource).State = EntityState.Modified;
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
        /// 添加资源信息
        /// </summary>
        /// <param name="resource">资源对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddResource(Resource resource)
        {
            bool operate = false;
            if (!ResourceExists(resource.id))
            {
                db.Resources.Add(resource);
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
        /// 删除资源信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        public MainResponse.DefaultResponse DeleteResource(int id)
        {
            bool operate = false;
            Resource resource = db.Resources.Find(id);
            if (resource != null)
            {
                db.Resources.Remove(resource);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    //删除服务器资源文件
                    if (resource.address != null)
                    {
                        File.Delete(resourcePath + "/" + resource.address);
                    }
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

        private bool ResourceExists(int id)
        {
            return db.Resources.Count(e => e.id == id) > 0;
        }
    }
}