using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Database_xss_sql_injection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dbRequest();
            return View();
        }

        
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult DoLogin()
        {
            var username = Request["username"];
            var password = Request["password"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf";

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT [Id], [username], [password] FROM [dbo].[User] WHERE [username] ='"+username+ "' AND [password] = '" + password;
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                ViewBag.Message = "success";

                while (reader.Read())
                {
                    ViewBag.Message += reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }
            else
            {
                ViewBag.Message = "nothing to read of";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            var feedback = Request["feedback"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf";

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO [dbo].[Feedback] SET [feedback] = '" + feedback + "'";
            cmd.Connection = con;

            con.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                ViewBag.Message = "success";

                while (reader.Read())
                {
                    ViewBag.Message += reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2);
                }
            }
            else
            {
                ViewBag.Message = "nothing to read of";
            }

            return View();
        }

        public void dbRequest()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\\C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf";

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT [Id] ,[username] ,[password] FROM [dbo].[User]";
            cmd.Connection = con;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}", reader.GetInt32(0), reader.GetString(1));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
        }
    }
}