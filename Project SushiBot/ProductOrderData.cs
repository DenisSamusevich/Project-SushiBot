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
        internal string Login { get; }
        DateTime DateOrder { get; set; }
        internal string NumberOrder { get; set; }
        List<ProductData> Product { get; }
        double TotalPrice { get; }
        EnumStatusOrder EnumStatusOrder { get; set; }
        Address Address { get; set; }
        string Phone { get; set; }
        internal ProductOrderData() { }
        internal ProductOrderData(string login, List<ProductData> productData)
        {
            Login = login;
            Product = productData;
            for (int i = 0; i < productData.Count; i++)
            {
                TotalPrice += productData[i].Price * productData[i].Amount;
            }
        }
        internal void SetInfoOrder(string orderStreet, string orderHouse, string orderApartment,string orderPhone)
        {
            DateOrder = DateTime.Now;
            NumberOrder =DateOrder.Month.ToString("D2") + DateOrder.Day.ToString("D2") + DateOrder.Hour.ToString("D2") + DateOrder.Minute.ToString("D2") + DateOrder.Second.ToString("D2");
            EnumStatusOrder = EnumStatusOrder.OrderProcessing;
            Address = new Address(orderStreet, orderHouse, orderPhone);
            Phone = orderPhone;
        }

        internal void OrderDataWrite(bool fullInfo)
        {
            Console.WriteLine("Заказ №{0} был сформирова {1}", NumberOrder, DateOrder);
            Console.WriteLine("В него входило:");
            for (int i = 0; i < Product.Count; i++)
            {
                Console.Write(Product[i].Name);
                Console.SetCursorPosition(25, Console.CursorTop);
                Console.WriteLine(Product[i].Amount.ToString()+" шт. - ");
                Console.WriteLine(Product[i].Price.ToString()+"Руб.");
            }
            Console.WriteLine("--------------------------------");
            Console.Write("Итого:");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine(TotalPrice.ToString() + "Руб.");
            Console.WriteLine();
            if (fullInfo)
            {
                Console.WriteLine("Адрес доставки:");
                Console.WriteLine(Address.ToString());
                Console.Write("Статус заказа:");
                Console.SetCursorPosition(15, Console.CursorTop);
                Console.WriteLine(StatusOrder());
            }
        }
        string StatusOrder()
        {
            string statusOrder = string.Empty;
            switch (EnumStatusOrder)
            {
                case EnumStatusOrder.WaitingForPayment:
                    {
                        statusOrder = "Ожидание оплаты";
                        break;
                    }
                case EnumStatusOrder.OrderProcessing:
                    {
                        statusOrder = "Заказ в обработке";
                        break;
                    }
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
                case EnumStatusOrder.OrderСancelled:
                    {
                        statusOrder = "Заказ отменен";
                        break;
                    }
            }
            return statusOrder;
        }

    }
}
