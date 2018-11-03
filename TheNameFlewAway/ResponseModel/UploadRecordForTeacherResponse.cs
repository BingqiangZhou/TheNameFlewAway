using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 上传记录相关API返回结果格式
    /// </summary>
    public class UploadRecordForTeacherResponse
    {
        /// <summary>
        /// 获取用户（教师）上传记录返回结果
        /// </summary>
        public struct GetUploadRecordByTeacherId
        {
            /// <summary>
            /// 上传记录列表
            /// </summary>   
            public List<UploadRecordForTeacher> uploadRecordForTeachers;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}