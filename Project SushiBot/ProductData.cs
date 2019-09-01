using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductData : ProductInfoData
    {   
        internal int Amount { get; }
        internal ProductData(string name, string descriptionText, string price, string amount): base(name, descriptionText, price)
        {
            Amount = AmountTextConversion(amount);
        }
        internal static int AmountTextConversion(string amountText)
        {
            if (int.TryParse(amountText, out int amount))
            {
                return amount > 0 ? amount : 0;
            }
            else
            {
                return 0;
            }
        }

    }
}
