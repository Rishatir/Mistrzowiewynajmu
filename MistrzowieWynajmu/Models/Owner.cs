using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistrzowieWynajmu.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public Owner() { }

        public Owner(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}