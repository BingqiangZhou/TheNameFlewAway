using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 实例教程相关API返回结果格式
    /// </summary>
    public class InstanceResponse
    {
        /// <summary>
        /// 查询所有实例API返回结果格式
        /// </summary>
        public struct GetAllInstances
        {
            /// <summary>
            /// 实例信息列表
            /// </summary>
            public List<MainResponse.DataMap> instances;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }

        // <summary>
        /// 通过id查询单个进阶知识API返回结果格式
        /// </summary>
        public struct GetInstance
        {
            /// <summary>
            /// 进阶知识信息
            /// </summary>
            public Instance instance;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}