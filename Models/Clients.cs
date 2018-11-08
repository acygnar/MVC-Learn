using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteDB.Models
{
    public class Clients
    {
        
        public int IdClients { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string message { get; set; }

    }
}
