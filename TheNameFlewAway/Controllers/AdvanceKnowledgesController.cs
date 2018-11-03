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
            return new AdvanceKnowledgeResponse.GetAdvanceKnowledge()
            { advanceKnowledge = advanceKnowledge, operate = operate };
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
        /// <param name="advanceKnowledge">进阶知识对象</param>
        /// <param name="resourceids">进阶知识资源列表</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddAdvanceKnowledge(AdvanceKnowledge advanceKnowledge, List<int> resourceids)
        {
            bool operate = false;
            if (!AdvanceKnowledgeExists(advanceKnowledge.id))
            {
                db.AdvanceKnowledges.Add(advanceKnowledge);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                    //添加资源
                    if (resourceids.Count > 0)
                    {
                        foreach (var item in resourceids)
                        {
                            db.AdvanceKonwledgeAndResources.Add(new AdvanceKonwledgeAndResource(advanceKnowledge.id, item));
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
                //删除进阶资源相关资源
                db.AdvanceKonwledgeAndResources.RemoveRange(
                    db.AdvanceKonwledgeAndResources.Where(
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
                        )
                );
                //删除进阶资源
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