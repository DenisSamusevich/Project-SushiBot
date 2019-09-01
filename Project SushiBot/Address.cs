using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    struct Address
    {
        string Street { get; }
        string House { get; }
        string Apartment { get; }
        public override string ToString()
        {
            string stringAddress = "Ул. " + Street + ", д. " + House + Apartment == string.Empty ? "." : (", кв. " + Apartment + ".");
            return stringAddress;
        }
    }
}
