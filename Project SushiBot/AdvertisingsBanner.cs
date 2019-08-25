using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class AdvertisingsBanner
    {

        static FileInfo File { get; } = new FileInfo(@"E:\LearnC#\File.txt");
        internal static string[] Banners { get; }
        static AdvertisingsBanner()
        {
            Banners = AdvertisingsBannerReadFile(NumberAdvertisingsReadFile());
        }
        internal string RandomBanner()
        {
            Random random = new Random();
            return Banners[random.Next(0, Banners.Length)];
        }
        internal static int NumberAdvertisingsReadFile()
        { 
            string stringLine = string.Empty;
            int numberAdvertisings = 0;
            FileStream fs = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sw = new StreamReader(fs, Encoding.Default);
            while (true)
            {
                stringLine = sw.ReadLine();
                if (stringLine == null)
                {
                    break;
                }
                else if (stringLine.Equals("start"))
                {
                    numberAdvertisings += 1;
                }
            }
            sw.Close();
            return numberAdvertisings;
        }
        internal static string[] AdvertisingsBannerReadFile(int numberAdvertisings)
        {
            FileStream fs = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sw = new StreamReader(fs, Encoding.Default);
            string[] returnAdvertisingsBanners = new string[numberAdvertisings];
            string stringLineRead = string.Empty;
            for (int i = 0; i < returnAdvertisingsBanners.Length; i++)
            {
                string[] stringAdvertisingBanner = new string[6];
                while (true)
                {
                    stringLineRead = sw.ReadLine();
                    if (stringLineRead.Equals("start"))
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            stringAdvertisingBanner[j] = sw.ReadLine();
                        }
                        returnAdvertisingsBanners[i] = string.Join("\n", stringAdvertisingBanner);
                        break;
                    }
                }
            }
            sw.Close();
            //int numberArray = 0;
            //for (int i = 0; i < stringAdvertisingsBanners.Length; i++)
            //{
            //    if (stringAdvertisingsBanners[i] !=null)
            //    {
            //        numberArray += 1;
            //    }
                
            //}
            //string[] returnAdvertisingsBanners = new string[numberArray];
            //for (int i = 0; i < returnAdvertisingsBanners.Length; i++)
            //{
            //    returnAdvertisingsBanners[i] = stringAdvertisingsBanners[i];
            //}
            return returnAdvertisingsBanners;
        }
    }
}
