using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductOrderDataBaseRepository
    {
        public static List<ProductOrderData> AllProductOrderData()
        {
            return ProductOrderDataBase.AllProductOrderData;
        }
        public static List<ProductOrderData> AllProductOrderUserData(string userLogin)
        {
            return ProductOrderDataBase.FindLogin(userLogin);
        }
        public static void CreateProductOrderUserData(ProductOrderData productOrderUserData)
        {
            ProductOrderDataBase.Insert(productOrderUserData);
        }
        public void UpdateProductOrderUserData(ProductOrderData productOrderUserData)
        {
            ProductOrderDataBase.Update(productOrderUserData);
        }
        public static ProductOrderData ProductOrderUserDataByIndex(ref int index, string userLogin)
        {
            ProductOrderDataBase.AllProductOrderUserDataSet(userLogin);
            return ProductOrderDataBase.FindCurrentUserIndex(ref index);
        }
        public static void SaveAllProductOrderData()
        {
            ProductOrderDataBase.ProductOrderWriteFile();
        }
        public static void UpdateStatusOrderData(ProductOrderData productOrderUserData)
        {
            ProductOrderDataBase.UpdateStatusOrder(productOrderUserData);
            ProductOrderDataBase.Update(productOrderUserData);
        }
    }
}
