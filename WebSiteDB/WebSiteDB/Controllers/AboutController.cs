using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebSiteDB.Controllers
{
    public class AboutController : Controller
    {
        [Route("[action]")]
        public ActionResult About()
        {
            string MyConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;;database=portfolio;SslMode=none";
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select Text FROM aboutme";
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                var aboutmetext = reader[0];
                ViewData["aboutmetext"] = aboutmetext;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                
                if (connection.State == ConnectionState.Open)
                {
                    ViewData["Status"] = "Połączono z bazą danych";
                }
            }
            return View();
        }
        
    }
}