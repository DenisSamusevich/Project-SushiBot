using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{

    internal class Address <T1,T2,T3>
    {
        public T1 Street { get; }
        public T2 House { get; }
        public T3 Apartment { get; }

        public Address(string street, string house, string apartment)
        {
            Street = ConvertTypeT1(street);
            House = ConvertTypeT2(house);
            Apartment = ConvertTypeT3(apartment);
        }
        public override string ToString()
        {
            string stringAddress = string.Format("Ул. {0}, д. {1}{2}", Street.ToString(), House.ToString(), (Apartment.ToString() == string.Empty ? "." : (", кв. " + Apartment.ToString() + ".")));
            return stringAddress;
        }
        internal T1 ConvertTypeT1(string street)
        {
            object objectStreet=null;
            if (typeof(T1)== typeof(int))
            {
                objectStreet = Convert.ToInt32(street);
            }
            else if((typeof(T1) == typeof(string)))
            {
                objectStreet = Convert.ToString(street);
            }
            return (T1)objectStreet;
        }
        internal T2 ConvertTypeT2(string street)
        {
            object objectStreet = null;
            if (typeof(T2) == typeof(int))
            {
                objectStreet = Convert.ToInt32(street);
            }
            else if ((typeof(T2) == typeof(string)))
            {
                objectStreet = Convert.ToString(street);
            }
            return (T2)objectStreet;
        }
        internal T3 ConvertTypeT3(string street)
        {
            object objectStreet = null;
            if (typeof(T3) == typeof(int))
            {
                objectStreet = Convert.ToInt32(street);
            }
            else if ((typeof(T3) == typeof(string)))
            {
                objectStreet = Convert.ToString(street);
            }
            return (T3)objectStreet;
        }
    }
}
