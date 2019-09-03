using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Project_SushiBot
{
    struct Address
    {
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public Address(string street,string house,string apartment)
        {
            Street = street;
            House = house;
            Apartment = apartment;
        }
        public override string ToString()
        {
            string stringAddress = "Ул. " + Street + ", д. " + House + (Apartment == string.Empty ? "." : (", кв. " + Apartment + "."));
            return stringAddress;
        }
    }
}
