using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductData : ProductInfoData, IDisposable
    {
        public int Amount { get; set; }

        internal ProductData() { }
        internal ProductData(string name, string descriptionText, string price, int amount) : base(name, descriptionText, price)
        {
            Amount = amount;
        }
        internal ProductData(ProductInfoData productInfoData, int amount) : base(productInfoData.Name, string.Empty, productInfoData.Price.ToString())
        {
            Amount = amount;
        }
        internal void ProductDataOrderWrite()
        {
            Console.Write(Name);
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.Write(Amount.ToString() + " шт. - ");
            Console.WriteLine((Price* Amount).ToString() + " Руб.");
        }
        internal double ProductTotalPrice()
        {
            return (Price * Amount);
        }
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Amount = 0;
                base.Dispose();
            }
        }
        ~ProductData()
        {
            Dispose(false);
        }
    }
}
