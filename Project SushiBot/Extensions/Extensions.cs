using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    internal static class AdvertisingsBannerDataBaseExtensions
    {
        public static string RandomBanner(this AdvertisingsBannerDataBase bannerDataBase)
        {
            try
            {
                if (bannerDataBase.Banners == null)
                {
                    throw new ArrayNotFoundExeption("Ошибка чтения данных");
                }
                else
                {
                    Random random = new Random();
                    return bannerDataBase.Banners[random.Next(0, bannerDataBase.Banners.Length)];
                }
            }
            catch
            {
                return string.Empty;
            }

        }
    }
}
