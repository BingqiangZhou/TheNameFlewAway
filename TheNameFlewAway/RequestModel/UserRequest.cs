using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheNameFlewAway.RequestModel
{
    /// <summary>
    /// 用户相关操作请求参数结构
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// 获取用户信息请求参数结构
        /// </summary>
        public struct GetUsersRequest
        {
            /// <summary>
            /// 页码
            /// </summary>
            public int page;
            /// <summary>
            /// 用户标识
            /// </summary>
            public int status;
        }
        /// <summary>
        /// 登录请求参数结构
        /// </summary>
        public struct LoginRequest
        {
            /// <summary>
            /// 用户手机号
            /// </summary>
            public string phone;
            /// <summary>
            /// 用户密码
            /// </summary>
            public string password;
        }

        /// <summary>
        /// 查找密码请求参数结构
        /// </summary>
        public struct FindPassword
        {
            /// <summary>
            /// 用户名
            /// </summary>
            public string name;
            /// <summary>
            /// 用户手机号
            /// </summary>
            public string phone;
            /// <summary>
            /// 旧密码
            /// </summary>
            public string oldPassword;
            /// <summary>
            /// 新密码
            /// </summary>
            public string newPassword;
        }
    }
}