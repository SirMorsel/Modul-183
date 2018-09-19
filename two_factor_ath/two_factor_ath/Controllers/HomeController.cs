using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace two_way_authentification.Controllers
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

        [HttpPost]
        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];

            if (username == "test" && password == "test")
            {
                var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");
                var secret = "TEST_SECRET";

                var postData = "api_key=baa99127";
                postData += "&api_secret=GGjwYqY98MYcZveA";
                postData += "&to=41796709107 ";
                postData += "&from=\"LosDosTacos\"";
                postData += "&text=\"" + secret + "\"";

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                ViewBag.Message = responseString;
            }
            else
            {
                ViewBag.Message = "Wrong Credentials";
            }
            return View();
        }

        [HttpPost]
        public void TokenLogin()
        {
            var token = Request["token"];

            if (token == "TEST_SECRET")
            {
                Console.Write(Request["token"]);
            }
            else
            {
                Console.Write(Request["token"]);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}