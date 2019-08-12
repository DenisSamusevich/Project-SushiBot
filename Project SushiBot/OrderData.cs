﻿using System;
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
        Price TotalPrice { get; }
        EnumStatusOrder EnumStatusOrder { get; }
        Address Address { get; set; } 
        int Phone { get; set; } 
        internal void OrderDataWrite(bool fullInfo)
        {
            Console.WriteLine("Заказ №{0} был сформирова {1}", NumberOrder, DateOrder);
            Console.WriteLine("В него входило:");
            for (int i = 0; i < Product.Length; i++)
            {
                Console.Write(Product[i].Name);
                Console.SetCursorPosition(25, Console.CursorTop);
                Console.WriteLine("- "+Product[i].Price.ToString()+"Руб.");
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
    class Product
    {
        internal string Name { get; }
        string Description { get; }
        internal Price Price { get; }
        internal int Amount { get; set; }
        internal void ProductDataWrite()
        {
            Console.WriteLine(Name);
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Цена:" + Price.ToString() + "Руб.");
        }
    }
    struct Price
    {
        int Ruble { get; }
        int Pennies { get; }
        public override string ToString()
        {
            string stringPrice = Ruble.ToString() + "," + Pennies.ToString();
            return stringPrice;
        }
    }
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
