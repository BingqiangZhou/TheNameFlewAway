using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 通用的返回结果
    /// </summary>
    public class MainResponse
    {
        /// <summary>
        /// 默认返回结果，true/false
        /// </summary>
        public struct DefaultResponse
        {
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
        /// <summary>
        /// 信息Map，存储单个信息对
        /// </summary>
        public class DataMap
        {
            /// <summary>
            /// 关键字key，如id
            /// </summary>
            public int key;
            /// <summary>
            /// 值value，如name
            /// </summary>
            public string value;

            /// <summary>
            /// 数据对构造函数
            /// </summary>
            /// <param name="key">关键字</param>
            /// <param name="value">对应值</param>
            public DataMap(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
            /// <summary>
            /// 数据对构造函数
            /// </summary>
            public DataMap()
            {

            }
        }
    }
}