using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class NewsDataRepository
    {
        public static NewsData GetNewsDataByIndex(ref int indexNews)
        {
            NewsDataBase newsDataBase = new NewsDataBase();
            NewsData newsData = newsDataBase.FindIndex(ref indexNews);
            newsDataBase.Dispose();
            return newsData;
        }
    }
}
