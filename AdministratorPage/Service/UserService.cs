using AdministratorPage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdministratorPage.Service
{
    public class UserService
    {
        private TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="status">用户标识，0表示所有用户</param>
        /// <returns>返回所有用户信息</returns>
        public List<User> GetUsers(int status)
        {
            if(status == 0)
            {
                return db.Users.ToList();
            }
            else
            {
                return db.Users.Where(
                        delegate (User user)
                        {
                            if (user.status == status - 1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    ).ToList();
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回用户信息</returns>
        public User GetUserInfo(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.Users.Find(id);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>是否添加成功</returns>
        public bool AddUser(User user)
        {
            if (!UserExists(user.id) && FindUserByPhone(user.phone) == null)
            {
                user.status = 1;//标记为学生
                db.Users.Add(user);
                int count = db.SaveChanges();
                if(count != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool EditUser(User user)
        {
            if(user != null)
            {
                db.Entry(user).State = EntityState.Modified;
                int count = db.SaveChanges();
                if (count != 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            int count = db.SaveChanges();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }

        public bool UserExists(int id)
        {
            if(db.Users.Find(id) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 通过用户手机号查询用户
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>返回用户信息</returns>
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