using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 展示作品类型相关API返回结果结构
    /// </summary>
    public class ExhibitionTypeResponse
    {
        /// <summary>
        /// 查询所有作品类别API返回结果格式
        /// </summary>
        public struct GetAllExhibitionTypes
        {
            /// <summary>
            /// 作品类别列表
            /// </summary>
            public List<ExhibitionType> exhibitionTypes;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }

        /// <summary>
        /// 查询一个类别所有作品部分信息API返回结果格式
        /// </summary>
        public struct GetExhibitionByExhibitionTypeId
        {
            /// <summary>
            /// 作品类别列表
            /// </summary>
            public List<ExhibitionPartInfo> exhibitionPartInfos;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
        /// <summary>
        /// 作品展示部分信息
        /// </summary>
        public class ExhibitionPartInfo
        {
            /// <summary>
            /// 作品id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 作品名
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 作者
            /// </summary>
            public string author { get; set; }
            /// <summary>
            /// 作品描述
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 作品图片
            /// </summary>
            public string showimage { get; set; }

            /// <summary>
            /// 展示作品部分信息全参构造函数
            /// </summary>
            /// <param name="id">作品id</param>
            /// <param name="name">作品名称</param>
            /// <param name="author">作品作者</param>
            /// <param name="description">作品描述</param>
            /// <param name="showimage">作品图片</param>
            public ExhibitionPartInfo(int id, string name, string author, string description, string showimage)
            {
                this.id = id;
                this.name = name;
                this.author = author;
                this.description = description;
                this.showimage = showimage;
            }
        }
    }
}