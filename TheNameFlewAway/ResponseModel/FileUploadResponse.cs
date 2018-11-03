using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 文件上传相关API返回结果格式
    /// </summary>
    public class FileUploadResponse
    {
        /// <summary>
        /// 文件上传返回结果
        /// </summary>
        public struct FileUpload
        {
            /// <summary>
            /// 服务器文件名
            /// </summary>
            public string fileName;
            /// <summary>
            /// 上传时间
            /// </summary>
            public string uploadTime;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}