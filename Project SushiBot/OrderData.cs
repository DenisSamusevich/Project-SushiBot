using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class OrderData
    {
        DateTime DateOrder { get; }
        int NumberOrder { get; }
        Product[] Product { get; }
        Price totalPrice { get; }
        EnumStatusOrder EnumStatusOrder { get; }
    }
    class Product
    {
        string Name { get; }
        string Description { get; }
        Price Price { get; }
        int Amount { get; }
    }
    struct Price
    {
        int Ruble;
        int Pennies;
    }
}
