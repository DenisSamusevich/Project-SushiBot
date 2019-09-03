using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_SushiBot
{
    class ProductOrderData
    {
        public string Login { get; set; }
        public DateTime DateOrder { get; set; }
        public  string NumberOrder { get; set; }
        public List<ProductData> Product { get; set; }
        public double TotalPrice { get; set; }
        public EnumStatusOrder EnumStatusOrder { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        internal ProductOrderData() { }
        internal ProductOrderData(string login, List<ProductData> productData)
        {
            Login = login;
            Product = productData;
            for (int i = 0; i < productData.Count; i++)
            {
                TotalPrice += Product[i].ProductTotalPrice();
            }
        }
        internal string GetLoginOrder()
        {
            return Login;
        }
        internal string GetNumberOrder()
        {
            return NumberOrder;
        }
        internal EnumStatusOrder GetEnumStatusOrder()
        {
            return EnumStatusOrder;
        }
        internal void SetInfoOrder(string orderStreet, string orderHouse, string orderApartment,string orderPhone)
        {
            DateOrder = DateTime.Now;
            NumberOrder =DateOrder.Month.ToString("D2") + DateOrder.Day.ToString("D2") + DateOrder.Hour.ToString("D2") + DateOrder.Minute.ToString("D2") + DateOrder.Second.ToString("D2");
            EnumStatusOrder = EnumStatusOrder.OrderMaking;
            Address = new Address(orderStreet, orderHouse, orderApartment);
            Phone = orderPhone;
        }
        internal void OrderDataWrite()
        {
            Console.WriteLine("Заказ №{0} был сформирова {1}", NumberOrder, DateOrder);
            Console.WriteLine("В него входило:");
            for (int i = 0; i < Product.Count; i++)
            {
                Product[i].ProductDataOrderWrite();
            }
            Console.WriteLine("------------------------------------------");
            Console.Write("Итого:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine(TotalPrice.ToString() + " Руб.");
            Console.Write("Адрес доставки:");
            Console.WriteLine(Address.ToString());
            Console.Write("Статус заказа:");
            Console.SetCursorPosition(15, Console.CursorTop);
            Console.WriteLine(StatusOrder());
        }
        internal void OrderDataPriceWrite()
        {
            Console.WriteLine("Состав вашего заказа:");
            for (int i = 0; i < Product.Count; i++)
            {
                Product[i].ProductDataOrderWrite();
            }
            Console.WriteLine("------------------------------------------");
            Console.Write("Итого:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine(TotalPrice.ToString() + " Руб.");
        }
        string StatusOrder()
        {
            string statusOrder = string.Empty;
            switch (EnumStatusOrder)
            {
                case EnumStatusOrder.OrderMaking:
                    {
                        statusOrder = "Заказ комплектуется";
                        break;
                    }
                case EnumStatusOrder.OrderDelivery:
                    {
                        statusOrder = "Заказ доставляется";
                        break;
                    }
                case EnumStatusOrder.OrderСompleted:
                    {
                        statusOrder = "Заказ выполнен";
                        break;
                    }
            }
            return statusOrder;
        }
        internal void ChangeOrderMakingToOrderDelivery()
        {
            EnumStatusOrder = EnumStatusOrder.OrderDelivery;
        }
        internal void ChangeOrderDeliveryToOrderСompleted()
        {
            EnumStatusOrder = EnumStatusOrder.OrderСompleted;
        }
    }
}
