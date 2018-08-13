using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteDB.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Projects()
        {
            return View();
        }
    }
}