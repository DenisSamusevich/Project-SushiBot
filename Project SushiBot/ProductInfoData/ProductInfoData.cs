using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductInfoData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        internal ProductInfoData() { }
        internal ProductInfoData(string name, string descriptionText, string price)
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
            Console.WriteLine("Цена:" + Price.ToString() + " Руб.");
        }
        internal static string DescriptionTextConversion(string DescriptionText)
        {
            if (DescriptionText.Length < 79)
            {
                return DescriptionText;
            }
            else
            {
                int lastindex = DescriptionText.LastIndexOf(' ', 79);
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
