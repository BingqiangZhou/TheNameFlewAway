using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 资源类型返回结果格式
    /// </summary>
    public class ResourceTypeResponse
    {
        /// <summary>
        /// 资源类型相关API的返回结果
        /// </summary>
        public struct GetResourceTypes
        {
            /// <summary>
            /// 资源信息类型列表
            /// </summary>   
            public List<ResourceType> resourceTypes;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}