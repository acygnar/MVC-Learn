using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteDB.Models
{
    public class Clients
    {
        [ScaffoldColumn(false)]
        public int IdClients { get; set; }
        [Display(Name ="Imię")]
        [Required(ErrorMessage ="Wprowadź imię")]
        [StringLength(30)]
        public string name { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Wprowadź nazwisko")]
        [StringLength(30)]
        public string surname { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Wprowadź adres email")]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Numer telefonu")]/// Wprowadzic wyrazenie regularne 
        public string phonenumber { get; set; }
        [Display(Name = "Wiadomość")]
        [Required(ErrorMessage = "Wpisz treść wiadomości")]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }

    }
}
