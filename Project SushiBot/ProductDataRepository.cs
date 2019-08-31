using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ProductDataRepository
    {
        public static ProductData GetProductDataByindex(ref int indexMenu, ref int indexProduct)
        {
            return ProductDataBase.FindIndex(ref indexMenu, ref indexProduct);
        }
    }
}
