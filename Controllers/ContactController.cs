using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebSiteDB.Models;


namespace WebSiteDB.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(Clients clients)
           
        {
            string name = HttpContext.Request.Form["name"];
            string surname = HttpContext.Request.Form["surname"];
            string email = HttpContext.Request.Form["email"];
            string phonenumber = HttpContext.Request.Form["phonenumber"];
            string message = HttpContext.Request.Form["message"];
            if (!ModelState.IsValid)
            {
                return View("contact", clients);
            }
            else
            {
                string MyConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=portfolio;SslMode=none";
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();

                try
                {
                    MySqlCommand cmdSend = connection.CreateCommand();
                   cmdSend.CommandText = ("INSERT INTO clients (name,surname,email,phonenumber,message) VALUES ('" + name + "','" + surname + "','" + email + "','" + phonenumber + "','" + message + "')");
                    cmdSend.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return View("ContactSend");
        }
    }
}
