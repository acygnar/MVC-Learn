using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ViewModels;

namespace WebApplication3.Repository
{
    public class PersonRepository
    {


        ///dekalrowanie zmiennych
        ///TODO: łaczymy sie z baza w tym miejscu  ///robimy tu metode do laczenia z baza
        public Person GetPersonByID(int perosnId)
        {

            var person = new Person
            {
                id = 1,
                name = "Adrian",
                surname = "Cygnar",

            };
            var person2 = new Person
            {
                id = 2,
                name = "Grzegorz",
                surname = "Cygnar",

            };
            return person;

        }
    }
}
