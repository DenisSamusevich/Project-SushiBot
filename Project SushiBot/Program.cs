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
            EnumPage enumPage = EnumPage.Greeting;
            EnumInput enumInputKey = EnumInput.None;
            Start:
            switch (enumPage)
            {
                case EnumPage.Greeting:
                    {
                        PageProgram.PageGreeting(AdvertisingsBanner.RandomBanner());
                        StartPageGreeting:
                        enumInputKey = PageProgram.PageGreetingBottom();
                        switch (enumInputKey)
                        {
                            case EnumInput.LogIn:
                                {
                                    enumPage = EnumPage.LogIn;
                                    break;
                                }
                            case EnumInput.SignUp:
                                {
                                    enumPage = EnumPage.SingUp;
                                    break;
                                }
                            case EnumInput.News:
                                {
                                    enumPage = EnumPage.News;
                                    break;
                                }
                            case EnumInput.Exit:
                                {
                                    enumPage = EnumPage.SingUp;
                                    break;
                                }
                            default:
                                {
                                    goto StartPageGreeting;
                                }
                        }
                        goto Start;
                    }
                case EnumPage.News:
                    {
                        PageProgram.PageNews(AdvertisingsBanner.RandomBanner(),);
                        StartPageNews:

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


            PageProgram.PageRegisterNewUser(string.Empty, out int cursorPositionLeftInfo, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword);
            string userSurname = PageInput.InputSurname(cursorPositionLeftInfo, сursorPositionSurname);
            string userName = PageInput.InputName(cursorPositionLeftInfo, сursorPositionName);
            Console.Read();
        }
    }
}
