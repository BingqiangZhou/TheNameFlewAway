using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheNameFlewAway.RequestModel
{
    /// <summary>
    /// 资源相关请求参数结构
    /// </summary>
    public class ResourceRequest
    {
        /// <summary>
        /// 获取资源请求参数结构
        /// </summary>
        public struct GetResourcesRequest
        {
            /// <summary>
            /// 类型id
            /// </summary>
            public int typeId;
            /// <summary>
            /// 页码
            /// </summary>
            public int page;
        }
    }
}