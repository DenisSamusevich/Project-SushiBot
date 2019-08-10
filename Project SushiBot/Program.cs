using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Подгрузить банеры
            string[] Banners = new string[] { "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************" }; 
            AdvertisingsBanner advertisingsBanner = new AdvertisingsBanner(Banners);
            EnumPage enumInput = EnumPage.Greeting;
            Start:
            switch (enumInput)
            {
                case EnumPage.Greeting:
                    {
                        PageProgram.PageGreeting(advertisingsBanner.RandomBanner(), out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight);
                        goto Start;
                    }
                case EnumPage.News:
                    {
                        goto Start;
                    }
                case EnumPage.RegisterNewUser:
                    {
                        goto Start;
                    }
                case EnumPage.SingUp:
                    {
                        goto Start;
                    }
            }


            //PageProgram.PageRegisterNewUser(string.Empty, out int cursorPositionLeftInfo, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword);
            //string userSurname = PageInput.InputSurname(cursorPositionLeftInfo, сursorPositionSurname);
            //string userName = PageInput.InputName(cursorPositionLeftInfo, сursorPositionName);
            //Console.Read();
        }
    }
}
