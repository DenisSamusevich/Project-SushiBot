using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductInfoDataRepository
    {
        public static ProductInfoData GetProductDataByindex(ref int indexMenu, ref int indexProduct)
        {
            ProductInfoDataBase productInfoDataBase = new ProductInfoDataBase();
            ProductInfoData productInfoData = productInfoDataBase.FindIndex(ref indexMenu, ref indexProduct);
            productInfoDataBase.Dispose();
            return productInfoData;
        }
        public static string[] GetMenuData()
        {
            ProductInfoDataBase productInfoDataBase = new ProductInfoDataBase();
            string[] menuData  = productInfoDataBase.GetAllMenuData();
            productInfoDataBase.Dispose();
            return menuData;
        }
    }
}
