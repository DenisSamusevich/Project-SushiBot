using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class NewsDataBase
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"NewsData\News.txt");
        internal static NewsData[] AllNewsData { get; }
        static NewsDataBase()
        {
            AllNewsData = NewsReadFile(NumberNewsReadFile());
        }
        internal static int NumberNewsReadFile()
        {
            string lineRead = string.Empty;
            int numberNews = 0;
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            while (true)
            {
                lineRead = streamReader.ReadLine();
                if (lineRead == null)
                {
                    break;
                }
                else if (lineRead.Equals("News"))
                {
                    numberNews += 1;
                }
            }
            streamReader.Close();
            return numberNews;
        }
        internal static NewsData[] NewsReadFile(int numberNews)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            NewsData[] returnAllNewsData = new NewsData[numberNews];
            string lineRead = string.Empty;
            for (int i = 0; i < returnAllNewsData.Length; i++)
            {
                string[] stringNews = new string[3];
                while (true)
                {
                    lineRead = streamReader.ReadLine();
                    if (lineRead.Equals("News"))
                    {
                        for (int j = 0; j < stringNews.Length; j++)
                        {
                            stringNews[j] = streamReader.ReadLine();
                        }
                        returnAllNewsData[i] = new NewsData(stringNews[0], stringNews[1], stringNews[2]);
                        break;
                    }
                }
            }
            streamReader.Close();
            return returnAllNewsData;
        }
        internal static NewsData FindIndex(ref int index)
        {
            if (index> AllNewsData.Length-1)
            {
                index = AllNewsData.Length - 1;
            }
            else if (index<0)
            {
                index = 0;
            }
            return AllNewsData[index];
        }
    }
}
