using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TheNameFlewAway.Models;
using TheNameFlewAway.ResponseModel;

namespace TheNameFlewAway.Controllers
{
    /// <summary>
    /// 用户操作相关API
    /// </summary>
    public class UsersController : ApiController
    {
        private TrainingEntities db = new TrainingEntities();
        //每页数据数
        private int dataEveryPage = int.Parse(ConfigurationManager.AppSettings["EveryPageDataCount"]);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="page">页码号</param>
        /// <param name="status">用户标识</param>
        /// <returns>返回用户信息带分页与用户标识</returns>
        [HttpPost]
        public UserResponse.GetUsers GetUsers(int page,int status)
        {
            bool operate = false;
            IEnumerable<User> users = null;
            //缺省status=0 搜索所有用户
            if (status <= 0)
            {
                users = db.Users.ToList();
            }
            else //status=1 搜索学生，status=2搜索老师
            {
                users = db.Users.Where(
                        delegate (User user)
                        {
                            if (user.status == status - 1)
                            {
                                return true;
                            }
                            return false;
                        }
                    );
            }
            if (users.Count() > 0)
            {
                //分页
                if (page >= 1)
                {
                    //skip 以0开始计数
                    users = users.Skip((page - 1) * dataEveryPage - 1).Take(dataEveryPage);
                    if (users.Count() > 0)
                    {
                        operate = true;
                    }
                }
                else
                {
                    operate = false;
                }
            }
            return new UserResponse.GetUsers()
            { users = users.ToList(), operate = operate };
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone">用户手机号</param>
        /// <param name="password">用户密码</param>
        /// <returns>登录成功，返回用户信息；失败返回false</returns>
        [HttpPost]
        public UserResponse.LoginResponse Login(string phone, string password)
        {
            User user = FindUserByPhone(phone);
            bool operate = false;
            if (user != null && user.password.Equals(password))
            {
                operate = true;
            }
            return new UserResponse.LoginResponse()
            { user = user, operate = operate };
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="phone">用户手机号</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="NewPassword">新密码</param>
        /// <returns>注册成功返回true，失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse FindPassword(string name, string phone, string oldPassword, string NewPassword)
        {
            bool operate = false;
            User user = FindUserByPhone(phone);
            if (user != null && user.name.Equals(name) && user.password.Equals(oldPassword))
            {
                user.password = NewPassword;
                db.Entry<User>(user).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse AddUser(User user)
        {
            bool operate = false;
            if (!UserExists(user.id))
            {
                db.Users.Add(user);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse ModifyUser(User user)
        {
            bool operate = false;
            if (UserExists(user.id))
            {
                db.Entry(user).State = EntityState.Modified;
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>操作成功返回true，操作失败返回false</returns>
        [HttpPost]
        public MainResponse.DefaultResponse DeleteUser(int id)
        {
            bool operate = false;
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                int count = db.SaveChanges();
                if (count != 0)
                {
                    operate = true;
                }
            }
            return new MainResponse.DefaultResponse()
            { operate = operate };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回用户信息</returns>
        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }

        /// <summary>
        /// 通过用户手机号查询用户
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>返回用户信息</returns>
        [NonAction]
        public User FindUserByPhone(string phone)
        {
            var user = db.Users.Where(
                delegate (User u)
                {
                    if (u.phone.Equals(phone))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (user.Count() > 0)
            {
                return user.First();
            }
            return null;
        }
    }
}