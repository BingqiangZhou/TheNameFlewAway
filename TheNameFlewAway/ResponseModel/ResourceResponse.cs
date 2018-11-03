using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 资源相关API的返回结果
    /// </summary>
    public class ResourceResponse
    {
        /// <summary>
        /// 资源相关API的返回结果
        /// </summary>
        public struct GetResources
        {
                /// <summary>
                /// 资源信息列表
                /// </summary>   
                public List<Resource> resources;

                /// <summary>
                /// 操作结果标识,true 成功；false 失败
                /// </summary>
                public bool operate;
        }
    }
}