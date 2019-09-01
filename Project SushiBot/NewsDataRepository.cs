using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class NewsDataRepository
    {
        public static NewsData[] GetNewsData()
        {
            return NewsDataBase.AllNewsData;
        }
        public static NewsData GetNewsDataByIndex(ref int indexNews)
        {
            return NewsDataBase.FindIndex(ref indexNews);
        }
    }
}
