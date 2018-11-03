using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 展示作品相关API返回结果结构
    /// </summary>
    public class ExhibitionResponse
    {
        /// <summary>
        /// 查找展示作品API返回结果格式
        /// </summary>
        public struct GetExhibition
        {
            /// <summary>
            /// 作品详细信息
            /// </summary>   
            public Exhibition exhibition;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}