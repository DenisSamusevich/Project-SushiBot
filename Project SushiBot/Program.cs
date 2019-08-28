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
            string userLogin = string.Empty;
            EnumPage enumPage = EnumPage.Greeting;
            Start:
            switch (enumPage)
            {
                case EnumPage.Greeting:
                    {
                        PageProgram.PageGreeting(AdvertisingsBannerDataBase.RandomBanner());
                    StartPageGreeting:
                        enumPage = PageProgram.PageGreetingBottom();
                        //
                        goto Start;
                    }
                case EnumPage.Login:
                    {
                        PageProgram.PageUserLogin(AdvertisingsBannerDataBase.RandomBanner(),out СursorPosition сursorPositionLogin,out СursorPosition сursorPositionPassword);
                        userLogin = PageInput.InputLogin(сursorPositionLogin);
                        PageInput.InputPassword(сursorPositionPassword, userLogin);
                        enumPage = PageProgram.PageUserLoginBottom();
                        //
                        goto Start;
                    }
                case EnumPage.RegisterNewUser:
                    {
                        PageProgram.PageRegisterNewUser(AdvertisingsBannerDataBase.RandomBanner(), out СursorPosition сursorPositionRegisterSurname, out СursorPosition сursorPositionRegisterName, out СursorPosition сursorPositionRegisterEmail, out СursorPosition сursorPositionRegisterLogin, out СursorPosition сursorPositionRegisterPassword, out СursorPosition сursorPositionRegisterRepeatPassword);
                        string newUserSurname = PageInput.InputRegistrationSurname(сursorPositionRegisterSurname);
                        string newUserName = PageInput.InputRegistrationName(сursorPositionRegisterName);
                        string newUserEmail = PageInput.InputRegistrationEmail(сursorPositionRegisterEmail);
                        string newUserLogin = PageInput.InputRegistrationLogin(сursorPositionRegisterLogin);
                        string newUserPassword = PageInput.InputRegistrationPassword(сursorPositionRegisterPassword, сursorPositionRegisterRepeatPassword);
                        enumPage = PageProgram.PageUserLoginBottom();
                        //
                        goto Start;
                    }
                case EnumPage.News:
                    {
                        PageProgram.PageNews(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin),);
                        //
                        goto Start;
                    }
            }



            Console.Read();
        }
    }
}
