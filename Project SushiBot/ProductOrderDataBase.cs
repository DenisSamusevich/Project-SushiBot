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
        static List<ProductOrderData> ProductOrderDatas { get; }
        static ProductOrderDataBase()
        {
            ProductOrderDatas = ProductOrderReadFile();
        }
        internal static List<ProductOrderData> ProductOrderReadFile()
        {
            return JsonConvert.DeserializeObject<List<ProductOrderData>>(File.ReadAllText(Environment.CurrentDirectory + @"ProductOrderData\ProductOrder.Json"));
        }
        internal static List<ProductOrderData> FindLogin(string userLogin)
        {
            IEnumerable<ProductOrderData> ProductOrderUserDatas = from order in ProductOrderDatas
                                                                 where order.Login.Equals(userLogin)
                                                                 select order;
            List<ProductOrderData> returnProductOrderUserDatas = ProductOrderUserDatas.ToList();
            return returnProductOrderUserDatas;
        }

    }
}
