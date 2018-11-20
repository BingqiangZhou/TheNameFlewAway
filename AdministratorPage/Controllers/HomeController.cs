using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Request.Cookies["Name"] != null && Request.Cookies["Name"].Value.Equals("admin"))
            {
                return RedirectToAction("Index", "Users");
            }
            return View("SignIn");
        }
        public ActionResult SignIn(string Password)
        {
            if (Password.Equals("123456"))
            {
                Response.Cookies["Name"].Value = "admin";
                Response.Cookies["Name"].Expires = DateTime.Now.AddHours(2);
                return RedirectToAction("Index","Users");
            }
            return Content("你是假的假的管理员！");
        }
        public ActionResult SignOut()
        {
            Response.Cookies["Name"].Expires = DateTime.Now.AddHours(-1);
            return Redirect("https://bingqiangzhou.cn/trainingapi/");
        }
    }
}