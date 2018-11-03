using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 基础知识相关API返回结果结构
    /// </summary>
    public class KnowledgeResponse
    {
        /// <summary>
        /// 查询所有基础知识API返回结果格式
        /// </summary>
        public struct GetAllKnowledgesInfo
        {
            /// <summary>
            /// 基础知识信息列表
            /// </summary>
            public List<MainResponse.DataMap> knowledgesInfos;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }

        // <summary>
        /// 通过id查询单个基础知识API返回结果格式
        /// </summary>
        public struct GetKnowledge
        {
            /// <summary>
            /// 基础知识信息
            /// </summary>
            public Knowledge knowledge;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}