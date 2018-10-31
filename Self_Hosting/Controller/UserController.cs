using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Self_Hosting.Model;
using System.Data.Entity;


namespace Self_Hosting.Controller
{
    public class UserController : ApiController
    {
        TrainingEntities db = new TrainingEntities();

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="name">用户姓名</param>
        /// <param name="phone">用户手机号</param>
        /// <param name="password">用户密码</param>
        /// <returns>注册成功返回true，失败返回false</returns>
        [HttpGet]
        public Dictionary<string,object> Register(string name, string phone,string password,byte status=0)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            bool operate = false;
            if(FindUserByPhone(phone) == null)
            {
                operate = true;
                db.Users.Add(new User(name, phone, password, status));
                if (db.SaveChanges() > 0)
                {
                    operate = true;
                }
            }
            results.Add("operate", operate);
            return results;
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
        public Dictionary<string, object> FindPassword(string name, string phone, string oldPassword,string NewPassword)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            bool operate = false;
            User user = FindUserByPhone(phone);
            if ( user != null && user.name.Equals(name) && user.password.Equals(oldPassword))
            {
                user.password = NewPassword;
                db.Entry<User>(user).State = EntityState.Modified;
                if(db.SaveChanges() > 0)
                {
                    operate = true;
                }
            }
            results.Add("operate", operate);
            return results;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="phone">用户手机号</param>
        /// <param name="password">用户密码</param>
        /// <returns>登录成功，返回用户信息；失败返回false</returns>
        [HttpPost]
        public Dictionary<string, object> Login(string phone, string password)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            User user = FindUserByPhone(phone);
            bool operate = false;
            if (user != null && user.password.Equals(password))
            {
                operate = true;
                results.Add("id", user.id);
                results.Add("name", user.name);
                results.Add("phone", user.phone);
                results.Add("status", user.status);
            }
            results.Add("operate", operate.ToString());
            return results;
        }

        /// <summary>
        /// 查找所有用户信息
        /// </summary>
        /// <returns>查找成功返回所有用户信息，查找失败返回false</returns>
        [HttpGet]
        public Dictionary<string, object> FindAllUser(byte status=0)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
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
                            if (user.status == status-1)
                            {
                                return true;
                            }
                            return false;
                        }
                    );
            }
            if (users.Count() > 0)
            {
                operate = true;
                results.Add("Users", users);
                results.Add("count", users.Count());
            }
            results.Add("operate", operate);
            return results;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="name">用户姓名</param>
        /// <param name="password">用户密码</param>
        /// <param name="phone">用户手机号</param>
        /// <returns>修改成功返回true，修改失败返回false</returns>
        [HttpGet]
        public Dictionary<string,object> ModifyUser(int id,string name,string password,string phone)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            bool operate = false;
            User user = FindUserById(id);
            if (user != null)
            {
                user.name = name;
                user.password = password;
                user.phone = phone;
                db.Entry<User>(user).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    operate = true;
                }
            }
            results.Add("operate", operate);
            return results;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>删除用户成功返回true，否则返回false</returns>
        [HttpGet]
        public Dictionary<string, object> DeleteUser(int id)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            bool operate = false;
            User user = FindUserById(id);
            if (user != null)
            {
                db.Entry<User>(user).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    operate = true;
                }
            }
            results.Add("operate", operate);
            return results;
        }

        /// <summary>
        /// 通过用户手机号查询用户
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns>返回用户信息</returns>
        [NonAction]
        public User FindUserByPhone(string phone)
        {
            var user = db.Users.Where(delegate (User u)
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
            if(user.Count() > 0)
            {
                return user.First();
            }
            return null;
        }
        /// <summary>
        /// 通过用户id查找用户
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>返回用户信息，未找到则返回空</returns>
        [NonAction]
        public User FindUserById(int id)
        {
            var user = db.Users.Where(delegate (User u)
            {
                if (u.id == id)
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
