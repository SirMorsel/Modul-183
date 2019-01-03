using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];
            var stayLoggedIn = Request["stayLoggedIn"];
            var expireDate = -1;

            if(stayLoggedIn == "on")
            {
                expireDate = 14;
            }

            if (username == "test" && password == "test")
            {
                string cookievalue;
                if (Request.Cookies["cookie"] != null)
                {
                    cookievalue = Request.Cookies["cookie"].Value.ToString();
                }
                else
                {
                    Response.Cookies["cookie"].Value = "cookie value";
                }
                Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(expireDate);
                return View();
            }
            return Login();
        }
    }
}