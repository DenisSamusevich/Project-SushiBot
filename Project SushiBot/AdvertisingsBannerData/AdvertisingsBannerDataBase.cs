using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class AdvertisingsBannerDataBase
    {
        private static readonly Logger logger = new Logger();
        static FileInfo File { get; set; }
        internal string[] Banners { get; set; }

        internal AdvertisingsBannerDataBase()
        {
            File = new FileInfo(Environment.CurrentDirectory + @"\AdvertisingsData\Advertisings.txt");
            Banners = AdvertisingsBannerReadFile(NumberAdvertisingsReadFile());
        }
        internal static int NumberAdvertisingsReadFile()
        {
            try
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
            catch
            {
                logger.Error("\"start\" not found in file", Thread.CurrentThread);
                return 0;
            }
        }
        internal static string[] AdvertisingsBannerReadFile(int numberAdvertisings)
        {
            try
            {
                if (numberAdvertisings <= 0)
                {
                    throw new ArrayNotFoundExeption("Ошибка чтения данных");
                }
                else
                {
                    logger.Debag("Start advertisings database read", Thread.CurrentThread);
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
            catch
            {
                logger.Error("Advertisings not found", Thread.CurrentThread);
                return null;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Banners = null;
            }
        }
        ~AdvertisingsBannerDataBase()
        {
            Dispose(false);
        }
    }
}
