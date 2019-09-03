using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace Project_SushiBot
{
    class ProductOrderDataBase : IDisposable 
    {
        private static readonly Logger logger = new Logger();
        internal static List<ProductOrderData> AllProductOrderData { get; set; }
        internal static List<ProductOrderData> AllProductOrderUserData { get; set; }
        static ProductOrderDataBase()
        {
            List<ProductOrderData> productOrderReadFile = ProductOrderReadFile();
            if (productOrderReadFile == null)
            {
                AllProductOrderData = new List<ProductOrderData>();
            }
            else
            {
                AllProductOrderData = productOrderReadFile;
            }
        }
        internal static void AllProductOrderUserDataSet(string userLogin)
        {
            AllProductOrderUserData = FindLogin(userLogin);
        }
        internal static List<ProductOrderData> ProductOrderReadFile()
        {
            logger.Debag("Database order read from file", Thread.CurrentThread);
            return JsonConvert.DeserializeObject<List<ProductOrderData>>(File.ReadAllText(Environment.CurrentDirectory + @"\ProductOrderData\ProductOrder.Json"));
        }
        internal static void ProductOrderWriteFile()
        {
            logger.Debag("Database order write in file", Thread.CurrentThread);
            File.WriteAllText(Environment.CurrentDirectory + @"\ProductOrderData\ProductOrder.Json", JsonConvert.SerializeObject(AllProductOrderData, Formatting.Indented));
        }
        internal static List<ProductOrderData> FindLogin(string userLogin)
        {
            logger.Debag("Find order use login", Thread.CurrentThread);
            if (AllProductOrderData == null)
            {
                return null;
            }
            else
            {
                IEnumerable<ProductOrderData> ProductOrderUserData = from order in AllProductOrderData
                                                                     where order.GetLoginOrder().Equals(userLogin)
                                                                     select order;
                List<ProductOrderData> returnProductOrderUserData = ProductOrderUserData.ToList();
                return returnProductOrderUserData;
            }
        }
        internal static void Insert(ProductOrderData productOrderUserData)
        {
            logger.Debag("Order added in database", Thread.CurrentThread);
            AllProductOrderData.Add(productOrderUserData);
        }
        internal static void Update(ProductOrderData productOrderUserData)
        {
            logger.Debag("Order update in database", Thread.CurrentThread);
            for (int i = 0; i < AllProductOrderData.Count; i++)
            {
                if (AllProductOrderData[i].GetNumberOrder() == productOrderUserData.GetNumberOrder()&& AllProductOrderData[i].GetLoginOrder().Equals(productOrderUserData.GetLoginOrder()))
                {
                    AllProductOrderData[i] = productOrderUserData;
                }
            }
        }
        internal static ProductOrderData FindCurrentUserIndex(ref int index)
        {
            logger.Debag("Order find in database", Thread.CurrentThread);
            if (AllProductOrderUserData == null)
            {
                index = 0;
                return null;
            }
            if (index > AllProductOrderUserData.Count - 1)
            {
                index = AllProductOrderUserData.Count - 1;
            }
            else if (index < 0)
            {
                index = 0;
            }
            return AllProductOrderUserData[index];
        }
        internal static void UpdateStatusOrder(ProductOrderData productOrderUserData)
        {
            if (productOrderUserData.GetEnumStatusOrder() == EnumStatusOrder.OrderMaking)
            {
                productOrderUserData.ChangeOrderMakingToOrderDelivery();
            }
            else if(productOrderUserData.GetEnumStatusOrder() == EnumStatusOrder.OrderDelivery)
            {
                productOrderUserData.ChangeOrderDeliveryToOrderСompleted();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                AllProductOrderData = null;
                AllProductOrderUserData = null;
            }
        }
        ~ProductOrderDataBase()
        {
            Dispose(false);
        }
    }
}
