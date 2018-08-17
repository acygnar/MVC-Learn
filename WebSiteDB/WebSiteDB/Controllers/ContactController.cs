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
                    ///cmdSend.CommandText = ("INSERT INTO clients (name,surname,email,phonenumber,message) VALUES ('" + name.Value + "','" + surname.Text + "','" + email.Text + "','" + phonenumber.Text + "','" + message.Text + "')");
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
