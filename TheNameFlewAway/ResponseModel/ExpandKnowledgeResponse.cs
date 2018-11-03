using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 拓展知识相关API返回结果结构
    /// </summary>
    public class ExpandKnowledgeResponse
    {
        /// <summary>
        /// 查询所有拓展知识API返回结果格式
        /// </summary>
        public struct GetAllExpandKnowledges
        {
            /// <summary>
            /// 拓展知识信息列表
            /// </summary>
            public List<MainResponse.DataMap> expandKnowledges;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }

        // <summary>
        /// 通过id查询单个拓展知识API返回结果格式
        /// </summary>
        public struct GetExpandKnowledge
        {
            /// <summary>
            /// 拓展知识信息
            /// </summary>
            public ExpandKnowledge expandKnowledge;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}