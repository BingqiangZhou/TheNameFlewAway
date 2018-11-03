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
    /// 拓展知识相关API
    /// </summary>
    public class ExpandKnowledgesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有拓展知识信息
        /// </summary>
        /// <returns>返回拓展信息列表以及操作结果标识</returns>
        [HttpPost]
        public ExpandKnowledgeResponse.GetAllExpandKnowledges GetAllExpandKnowledges()
        {
            bool operate = false;
            List<MainResponse.DataMap> infos = db.ExpandKnowledges.Select(p=>new { p.id,p.key}).AsEnumerable()
                .Select(p => new MainResponse.DataMap(p.id, p.key)).ToList();
            if (infos != null && infos.Count > 0)
            {
                operate = true;
            }
            return new ExpandKnowledgeResponse.GetAllExpandKnowledges()
            { expandKnowledges = infos, operate = operate };
        }

        /// <summary>
        /// 通过id获取拓展知识信息
        /// </summary>
        /// <param name="id">拓展知识id</param>
        /// <returns>返回拓展信息列表以及操作结果标识</returns>
        [HttpPost]
        public ExpandKnowledgeResponse.GetExpandKnowledge GetExpandKnowledge(int id)
        {
            bool operate = true;
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            if (expandKnowledge == null)
            {
                operate = false;
            }
            return new ExpandKnowledgeResponse.GetExpandKnowledge()
            { expandKnowledge = expandKnowledge, operate = operate };
        }
        /// <summary>
        /// 修改拓展知识
        /// </summary>
        /// <param name="expandKnowledge">拓展知识对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyExpandKnowledge(ExpandKnowledge expandKnowledge)
        {
            bool operate = false;
            if (ExpandKnowledgeExists(expandKnowledge.id))
            {
                db.Entry(expandKnowledge).State = EntityState.Modified;
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
        /// 添加拓展知识
        /// </summary>
        /// <param name="expandKnowledge">拓展知识对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddExpandKnowledge(ExpandKnowledge expandKnowledge)
        {
            bool operate = false;
            if (!ExpandKnowledgeExists(expandKnowledge.id))
            {
                db.ExpandKnowledges.Add(expandKnowledge);
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
        /// 删除拓展知识
        /// </summary>
        /// <param name="id">拓展知识id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteExpandKnowledge(int id)
        {
            bool operate = false;
            ExpandKnowledge expandKnowledge = db.ExpandKnowledges.Find(id);
            if (expandKnowledge != null)
            {
                db.ExpandKnowledges.Remove(expandKnowledge);
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

        private bool ExpandKnowledgeExists(int id)
        {
            return db.ExpandKnowledges.Count(e => e.id == id) > 0;
        }
    }
}