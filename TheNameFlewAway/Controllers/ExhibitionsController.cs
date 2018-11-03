using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// 作品展示相关API
    /// </summary>
    public class ExhibitionsController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取展示作品信息
        /// </summary>
        /// <param name="id">展示作品id</param>
        /// <returns>返回单个展示作品信息</returns>
        [HttpPost]
        public ExhibitionResponse.GetExhibition GetExhibition(int id)
        {
            bool operate = false;
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition != null)
            {
                operate = true;
            }
            return new ExhibitionResponse.GetExhibition()
            { exhibition = exhibition, operate = operate };
        }

        /// <summary>
        /// 修改展示作品信息
        /// </summary>
        /// <param name="exhibition">展示作品对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyExhibition(Exhibition exhibition)
        {
            bool operate = false;
            if (ExhibitionExists(exhibition.id))
            {
                db.Entry(exhibition).State = EntityState.Modified;
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
        /// 添加展示作品信息
        /// </summary>
        /// <param name="exhibition">展示作品对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddExhibition(Exhibition exhibition)
        {
            bool operate = false;
            if (!ExhibitionExists(exhibition.id))
            {
                db.Exhibitions.Add(exhibition);
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
        /// 删除展示作品信息
        /// </summary>
        /// <param name="id">展示作品id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteExhibition(int id)
        {
            bool operate = false;
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition != null)
            {
                db.Exhibitions.Remove(exhibition);
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

        private bool ExhibitionExists(int id)
        {
            return db.Exhibitions.Count(e => e.id == id) > 0;
        }
    }
}