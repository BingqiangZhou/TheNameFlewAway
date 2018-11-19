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
    public class ExhibitionTypesController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();
        //每页数据数
        private int dataEveryPage = int.Parse(ConfigurationManager.AppSettings["EveryPageDataCount"]);

        /// <summary>
        /// 获取所有作品类别
        /// </summary>
        /// <returns>返回所有作品类别信息、数量以及操作标识</returns>
        [HttpPost]
        public ExhibitionTypeResponse.GetAllExhibitionTypes GetAllExhibitionTypes()
        {
            bool operate = false;
            List<ExhibitionType> exhibitionTypes = db.ExhibitionTypes.ToList();
            if(exhibitionTypes.Count > 0)
            {
                operate = true;
            }
            return new ExhibitionTypeResponse.GetAllExhibitionTypes()
            { exhibitionTypes=exhibitionTypes,operate=operate };
        }

        /// <summary>
        /// 通过作品类型id获取该类作品
        /// </summary>
        /// <param name="id">作品类型id</param>
        /// <returns>返回所有作品部分信息以及操作标识</returns>
        [HttpPost]
        public ExhibitionTypeResponse.GetExhibitionByExhibitionTypeId GetExhibitionByExhibitionTypeId(int id)
        {
            bool operate = false;
            ExhibitionType exhibitionType = db.ExhibitionTypes.Find(id);
            List<ExhibitionTypeResponse.ExhibitionPartInfo> exhibitionPartInfos = null;
            int count = 0;
            if (exhibitionType != null)
            {
                exhibitionPartInfos = db.Exhibitions
                    .Where(p => p.typeid == id).Select(p => new { p.id, p.name, p.showimage, p.author, p.description }).ToList()
                    .Select(p => new ExhibitionTypeResponse.ExhibitionPartInfo(p.id, p.name, p.author, p.description, p.showimage)).ToList();
                if(exhibitionPartInfos != null)
                {
                    operate = true;
                    count = exhibitionPartInfos.Count;
                }
            }
            return new ExhibitionTypeResponse.GetExhibitionByExhibitionTypeId()
            { exhibitionPartInfos = exhibitionPartInfos, operate = operate };
        }

        /// <summary>
        /// 修改作品类型
        /// </summary>
        /// <param name="exhibitionType">作品类型对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyExhibitionType(ExhibitionType exhibitionType)
        {
            bool operate = false;
            if (ExhibitionTypeExists(exhibitionType.id))
            {
                db.Entry(exhibitionType).State = EntityState.Modified;
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
        /// 添加作品类型
        /// </summary>
        /// <param name="exhibitionType">作品类型对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddExhibitionType(ExhibitionType exhibitionType)
        {
            bool operate = false;
            if (!ExhibitionTypeExists(exhibitionType.id))
            {
                db.ExhibitionTypes.Add(exhibitionType);
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
        /// 删除作品类型
        /// </summary>
        /// <param name="id">作品类型id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteExhibitionType(int id)
        {
            bool operate = false;
            ExhibitionType exhibitionType = db.ExhibitionTypes.Find(id);
            if (exhibitionType != null)
            {
                db.ExhibitionTypes.Remove(exhibitionType);
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

        private bool ExhibitionTypeExists(int id)
        {
            return db.ExhibitionTypes.Count(e => e.id == id) > 0;
        }
    }
}