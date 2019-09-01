using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Project_SushiBot
{
    class ProductOrderDataBase
    {
        //static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"ProductOrderData\ProductOrder.Json");
        internal static List<ProductOrderData> AllProductOrderData { get; }
        internal static List<ProductOrderData> AllProductOrderUserData { get; set; }
        static ProductOrderDataBase()
        {
            AllProductOrderData = ProductOrderReadFile();
        }
        internal static void AllProductOrderUserDataSet(string userLogin)
        {
            AllProductOrderUserData = FindLogin(userLogin);
        }

        internal static List<ProductOrderData> ProductOrderReadFile()
        {
            return JsonConvert.DeserializeObject<List<ProductOrderData>>(File.ReadAllText(Environment.CurrentDirectory + @"ProductOrderData\ProductOrder.Json"));
        }
        internal static void ProductOrderWriteFile()
        {
            File.WriteAllText(Environment.CurrentDirectory + @"ProductOrderData\ProductOrder.Json", JsonConvert.SerializeObject(AllProductOrderData));
        }
        internal static List<ProductOrderData> FindLogin(string userLogin)
        {
            IEnumerable<ProductOrderData> ProductOrderUserData = from order in AllProductOrderData
                                                                 where order.Login.Equals(userLogin)
                                                                 select order;
            List<ProductOrderData> returnProductOrderUserData = ProductOrderUserData.ToList();
            return returnProductOrderUserData;
        }
        internal static void Insert(ProductOrderData productOrderUserData)
        {
            AllProductOrderData.Add(productOrderUserData);
        }
        internal static void Update(ProductOrderData productOrderUserData)
        {
            for (int i = 0; i < AllProductOrderData.Count; i++)
            {
                if (AllProductOrderData[i].NumberOrder == productOrderUserData.NumberOrder&& AllProductOrderData[i].Login.Equals(productOrderUserData.Login))
                {
                    AllProductOrderData[i] = productOrderUserData;
                }
            }
        }
        internal static ProductOrderData FindCurrentUserIndex(ref int index)
        {
            if (AllProductOrderUserData == null)
            {
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
    }
}
