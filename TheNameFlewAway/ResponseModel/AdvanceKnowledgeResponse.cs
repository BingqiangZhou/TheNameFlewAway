using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 进阶知识相关API返回结果结构
    /// </summary>
    public class AdvanceKnowledgeResponse
    {
        /// <summary>
        /// 查询所有进阶知识API返回结果格式
        /// </summary>
        public struct GetAllAdvanceKnowledges
        {
            /// <summary>
            /// 进阶知识信息列表
            /// </summary>
            public List<MainResponse.DataMap> advanceKnowledges;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }

        // <summary>
        /// 通过id查询单个进阶知识API返回结果格式
        /// </summary>
        public struct GetAdvanceKnowledge
        {
            /// <summary>
            /// 进阶知识信息
            /// </summary>
            public AdvanceKnowledge advanceKnowledge;
            /// <summary>
            /// 进阶知识知识点
            /// </summary>
            public List<Resource> resources;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}