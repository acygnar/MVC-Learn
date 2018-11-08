using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repository;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private PersonRepository repo;
        public PersonController()
        {
            repo = new PersonRepository();
        }
        [HttpGet("{id}")]
        public Person Get(int id)
        {

            return repo.GetPersonByID(id);



        }

        [Route("[action]/{id}")]
        public ActionResult Person(int id)
        {

            ViewBag.Title = "Home";
            var person = repo.GetPersonByID(id);
            return View(person);
        }
    }
}