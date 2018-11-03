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
    /// 基础知识相关API
    /// </summary>
    public class KnowledgesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有基础知识信息
        /// </summary>
        /// <returns>返回基础信息列表以及操作结果标识</returns>
        [HttpPost]
        public KnowledgeResponse.GetAllKnowledgesInfo GetAllKnowledgesInfo()
        {
            bool operate = false;
            List<MainResponse.DataMap> infos = db.Knowledges.Select(p => new { p.id, p.key }).AsEnumerable()
                .Select(p => new MainResponse.DataMap(p.id, p.key)).ToList();
            if (infos != null && infos.Count > 0)
            {
                operate = true;
            }
            return new KnowledgeResponse.GetAllKnowledgesInfo()
            { knowledgesInfos=infos,operate= operate };
        }

        /// <summary>
        /// 通过id获取基础知识信息
        /// </summary>
        /// <param name="id">知识id</param>
        /// <returns>返回基础知识信息以及操作结果标识</returns>
        [HttpPost]
        public KnowledgeResponse.GetKnowledge GetKnowledge(int id)
        {
            bool operate = true;
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                operate = false;
            }
            return new KnowledgeResponse.GetKnowledge()
            { knowledge = knowledge, operate = operate };
        }

        /// <summary>
        /// 修改基础知识
        /// </summary>
        /// <param name="knowledge">基础知识对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyKnowledge(Knowledge knowledge)
        {
            bool operate = false;
            if (KnowledgeExists(knowledge.id))
            {
                db.Entry(knowledge).State = EntityState.Modified;
                int count = db.SaveChanges();
                if(count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 添加基础知识
        /// </summary>
        /// <param name="knowledge">基础知识对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddKnowledge(Knowledge knowledge)
        {
            bool operate = false;
            if (!KnowledgeExists(knowledge.id))
            {
                db.Knowledges.Add(knowledge);
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
        /// 删除基础知识
        /// </summary>
        /// <param name="id">基础知识id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteKnowledge(int id)
        {
            bool operate = false;
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge != null)
            {
                db.Knowledges.Remove(knowledge);
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
        [NonAction]
        private bool KnowledgeExists(int id)
        {
            return db.Knowledges.Count(e => e.id == id) > 0;
        }
    }
}