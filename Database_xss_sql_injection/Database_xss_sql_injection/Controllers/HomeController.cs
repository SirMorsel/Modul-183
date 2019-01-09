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

        [HttpPost]
        public ActionResult DoLogin()
        {
            var username = Request["username"];
            var password = Request["password"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT [Id], [username], [password] FROM [dbo].[User] WHERE [username] ='"+username+ "' AND [password] = '" + password + "'";
            cmd.Connection = con;

          //  con.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                ViewBag.Message = "success: ";

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

        [HttpPost]
        public ActionResult DoFeedback()
        {
            var feedback = Request["feedback"];

            if (feedback != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf;Integrated Security=True;Connect Timeout=30";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO [dbo].[Feedback] (feedback) VALUES ('" + feedback + "')";
                cmd.Connection = con;

                if (cmd.ExecuteNonQuery() != 0)
                {
                    ViewBag.Message = "success insert:" + feedback + " to DB!";
                }
                else
                {
                    ViewBag.Message = "nothing to read of";
                }
            }
            else
            {
                ViewBag.Message = "Do not let input-field empty";
            }

            return View();
        }

        public void dbRequest()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Patrick\\Documents\\sql_xss_injection.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
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