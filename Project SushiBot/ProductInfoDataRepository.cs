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
            return ProductInfoDataBase.FindIndex(ref indexMenu, ref indexProduct);
        }
    }
}
