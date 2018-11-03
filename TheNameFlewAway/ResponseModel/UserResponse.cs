using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheNameFlewAway.Models;

namespace TheNameFlewAway.ResponseModel
{
    /// <summary>
    /// 用户相关API的返回结果
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// 用户登录API返回结果格式
        /// </summary>
        public struct LoginResponse
        {
            /// <summary>
            /// 用户信息
            /// </summary>
            public User user;
            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
        /// <summary>
        /// 查找用户API返回结果格式
        /// </summary>
        public struct GetUsers
        {
            /// <summary>
            /// 用户信息列表
            /// </summary>   
            public List<User> users;

            /// <summary>
            /// 操作结果标识,true 成功；false 失败
            /// </summary>
            public bool operate;
        }
    }
}