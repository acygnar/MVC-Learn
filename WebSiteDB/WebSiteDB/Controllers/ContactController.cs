using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Contact(Clients clients )
        {
            return View();
        }
    }
}