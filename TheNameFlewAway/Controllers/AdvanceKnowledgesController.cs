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
using TheNameFlewAway.RequestModel;
using TheNameFlewAway.ResponseModel;

namespace TheNameFlewAway.Controllers
{
    /// <summary>
    /// 进阶知识相关API
    /// </summary>
    public class AdvanceKnowledgesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有进阶知识信息
        /// </summary>
        /// <returns>返回进阶信息列表以及操作结果标识</returns>
        [HttpPost]
        public AdvanceKnowledgeResponse.GetAllAdvanceKnowledges GetAllAdvanceKnowledges()
        {
            bool operate = false;
            List<MainResponse.DataMap> infos = db.AdvanceKnowledges.Select(p => new { p.id, p.key }).AsEnumerable()
                .Select(p => new MainResponse.DataMap(p.id, p.key)).ToList();
            if (infos != null && infos.Count > 0)
            {
                operate = true;
            }
            return new AdvanceKnowledgeResponse.GetAllAdvanceKnowledges()
            { advanceKnowledges = infos, operate = operate };
        }

        /// <summary>
        /// 通过id获取进阶知识信息
        /// </summary>
        /// <param name="id">进阶知识id</param>
        /// <returns>返回进阶信息列表以及操作结果标识</returns>
        [HttpPost]
        public AdvanceKnowledgeResponse.GetAdvanceKnowledge GetAdvanceKnowledge(int id)
        {
            bool operate = true;
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            if (advanceKnowledge == null)
            {
                operate = false;
            }
            List<AdvanceKonwledgeAndResource> advanceKonwledgeAndResources = db.AdvanceKonwledgeAndResources.Where(
                    delegate (AdvanceKonwledgeAndResource advanceKonwledgeAndResource)
                    {
                        if (advanceKonwledgeAndResource.id == id)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                ).ToList();
            List<Resource> resources = new List<Resource>();
            foreach (var item in advanceKonwledgeAndResources)
            {
                resources.Add(db.Resources.Find(item.resourceid));
            }
            return new AdvanceKnowledgeResponse.GetAdvanceKnowledge()
            { advanceKnowledge = advanceKnowledge, resources = resources, operate = operate };
        }

        /// <summary>
        /// 修改进阶知识
        /// </summary>
        /// <param name="advanceKnowledge">进阶知识对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyAdvanceKnowledge(AdvanceKnowledge advanceKnowledge)
        {
            bool operate = false;
            if (AdvanceKnowledgeExists(advanceKnowledge.id))
            {
                db.Entry(advanceKnowledge).State = EntityState.Modified;
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
        /// 添加进阶知识
        /// </summary>
        /// <param name="request">添加进阶知识请求参数对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddAdvanceKnowledge(AdvanceKnowledgeRequest.AddAdvanceKnowledge request)
        {
            bool operate = false;
            if (!AdvanceKnowledgeExists(request.advanceKnowledge.id))
            {
                db.AdvanceKnowledges.Add(request.advanceKnowledge);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                    //添加资源
                    if (request.resourceids.Count > 0)
                    {
                        foreach (var item in request.resourceids)
                        {
                            db.AdvanceKonwledgeAndResources.Add(new AdvanceKonwledgeAndResource(request.advanceKnowledge.id, item));
                            count = db.SaveChanges();
                            if (count != 0)
                            {
                                operate = true;
                            }
                            else
                            {
                                operate = false;
                                break;
                            }
                        }
                    }
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 删除进阶知识
        /// </summary>
        /// <param name="id">进阶知识id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteAdvanceKnowledge(int id)
        {
            bool operate = false;
            AdvanceKnowledge advanceKnowledge = db.AdvanceKnowledges.Find(id);
            if (advanceKnowledge != null)
            {
                //查询到进阶知识相关资源
                IEnumerable<AdvanceKonwledgeAndResource> advanceKonwledgeAndResources = db.AdvanceKonwledgeAndResources.Where(
                            delegate (AdvanceKonwledgeAndResource advanceKonwledgeAndResource)
                            {
                                if (advanceKonwledgeAndResource.id == id)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        ).ToList();
                //删除相关资源
                List<Resource> resources = new List<Resource>();
                foreach (var item in advanceKonwledgeAndResources)
                {
                    Resource resource = db.Resources.Find(item.resourceid);
                    {
                        if (resource != null)
                        {
                            resources.Remove(resource);
                        }
                    }
                }
                db.Resources.RemoveRange(resources);
                //删除进阶资源相关资源连接
                db.AdvanceKonwledgeAndResources.RemoveRange(advanceKonwledgeAndResources);
                //删除进阶知识
                db.AdvanceKnowledges.Remove(advanceKnowledge);
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

        private bool AdvanceKnowledgeExists(int id)
        {
            return db.AdvanceKnowledges.Count(e => e.id == id) > 0;
        }
    }
}