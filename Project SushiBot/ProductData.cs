using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductData
    {
        internal string Name { get; }
        protected string Description { get; }
        internal double Price { get; }
        internal ProductData(string name, string descriptionText, string price)
        {
            Name = name;
            Description = DescriptionTextConversion(descriptionText);
            Price = PriceTextConversion(price);
        }
        internal void ProductDataWrite()
        {
            Console.WriteLine(Name);
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.SetCursorPosition(0, 15); //цифры непонятные
            Console.WriteLine("Цена:" + Price.ToString() + "Руб.");
        }
        internal static string DescriptionTextConversion(string DescriptionText)
        {
            if (DescriptionText.Length < 80)
            {
                return DescriptionText;
            }
            else
            {
                int lastindex = DescriptionText.LastIndexOf(' ', 80);
                string stringStart = DescriptionText.Substring(0, lastindex + 1);
                string stringEnd = DescriptionText.Substring(lastindex + 1, DescriptionText.Length - lastindex - 1);
                string returnDescriptionText = stringStart + "\n" + DescriptionTextConversion(stringEnd);
                return returnDescriptionText;
            }
        }
        internal static double PriceTextConversion(string PriceText)
        {
            if (Double.TryParse(PriceText,out double Price))
            {
                return Price;
            }
            else
            {
                return 0;
            }
        }
    }
}
