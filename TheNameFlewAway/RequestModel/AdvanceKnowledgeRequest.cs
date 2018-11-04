using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.RequestModel
{
    /// <summary>
    /// 进阶知识
    /// </summary>
    public class AdvanceKnowledgeRequest
    {
        /// <summary>
        /// 添加进阶知识的请求参数结构
        /// </summary>
        public struct AddAdvanceKnowledge
        {
            /// <summary>
            /// 进阶函数
            /// </summary>
            public AdvanceKnowledge advanceKnowledge;

            /// <summary>
            /// 资源id
            /// </summary>
            public List<int> resourceids;
        }

    }
}