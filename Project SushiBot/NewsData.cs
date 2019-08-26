using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class NewsData
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"NewsData\News.txt");
        internal static News[] News { get; }
        static NewsData()
        {
            News = NewsReadFile(NumberNewsReadFile());
        }
        internal static int NumberNewsReadFile()
        {
            string stringLine = string.Empty;
            int numberAdvertisings = 0;
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            while (true)
            {
                stringLine = streamReader.ReadLine();
                if (stringLine == null)
                {
                    break;
                }
                else if (stringLine.Equals("start"))
                {
                    numberAdvertisings += 1;
                }
            }
            streamReader.Close();
            return numberAdvertisings;
        }
        internal static News[] NewsReadFile(int numberNews)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            News[] returnNews = new News[numberNews];
            string stringLineRead = string.Empty;
            for (int i = 0; i < returnNews.Length; i++)
            {
                string[] stringNews = new string[3];
                while (true)
                {
                    stringLineRead = streamReader.ReadLine();
                    if (stringLineRead.Equals("start"))
                    {
                        for (int j = 0; j < stringNews.Length; j++)
                        {
                            stringNews[j] = streamReader.ReadLine();
                        }
                        returnNews[i] = new News(stringNews[0], stringNews[1], stringNews[2]);
                        break;
                    }
                }
            }
            streamReader.Close();
            return returnNews;
        }
    }
    internal struct News
    {
        string NewsTitle { get; } 
        string NewsText { get; }
        string NewsLink { get; }
        internal News(string stringNewsTitle, string stringNewsText, string stringNewsLink)
        {
            NewsTitle = stringNewsTitle;
            NewsText = NewsTextConversion(stringNewsText);
            NewsLink = stringNewsLink;
        }
        internal static string NewsTextConversion(string stringNewsText)
        {
            if (stringNewsText.Length<80)
            {
                return stringNewsText;
            }
            else
            {
                int lastindex= stringNewsText.LastIndexOf(' ', 80);
                string stringStart = stringNewsText.Substring(0, lastindex + 1);
                string stringEnd = stringNewsText.Substring(lastindex + 1, stringNewsText.Length - lastindex - 1);
                string returnNewsText = stringStart + "\n" + NewsTextConversion(stringEnd);
                return returnNewsText;
            }
        }
    }

}
