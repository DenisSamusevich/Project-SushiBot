using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class AdvertisingsBannerDataBase
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory+ @"\AdvertisingsData\Advertisings.txt");
        internal static string[] Banners { get; }
        static AdvertisingsBannerDataBase()
        {
            Banners = AdvertisingsBannerReadFile(NumberAdvertisingsReadFile());
        }
        internal static string RandomBanner()
        {
            Random random = new Random();
            return Banners[random.Next(0, Banners.Length)];
        }
        internal static int NumberAdvertisingsReadFile()
        { 
            string stringLineRead = string.Empty;
            int numberAdvertisings = 0;
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            while (true)
            {
                stringLineRead = streamReader.ReadLine();
                if (stringLineRead == null)
                {
                    break;
                }
                else if (stringLineRead.Equals("start", StringComparison.Ordinal))
                {
                    numberAdvertisings += 1;
                }
            }
            streamReader.Close();
            return numberAdvertisings;
        }
        internal static string[] AdvertisingsBannerReadFile(int numberAdvertisings)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            string[] returnAdvertisingsBanners = new string[numberAdvertisings];
            string stringLineRead = string.Empty;
            for (int i = 0; i < returnAdvertisingsBanners.Length; i++)
            {
                string[] stringAdvertisingBanner = new string[6];
                while (true)
                {
                    stringLineRead = streamReader.ReadLine();
                    if (stringLineRead.Equals("start"))
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            stringAdvertisingBanner[j] = streamReader.ReadLine();
                        }
                        returnAdvertisingsBanners[i] = string.Join("\n", stringAdvertisingBanner);
                        break;
                    }
                }
            }
            streamReader.Close();
            return returnAdvertisingsBanners;
        }
    }
}
