using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserData
    {
        private string UserEmail { get; } = string.Empty;
        private string UserName { get; set; } = string.Empty;
        private string UserSurname { get; set; } = string.Empty;
        private string UserLogin { get; set; } = string.Empty;
        private string UserPassword { get; set; } = string.Empty;
        private string UserAddress { get; set; } = string.Empty;
        private string UserPhone { get; set; } = string.Empty;

        UserData(string userEmail, string userName, string userSurname, string userLogin, string userPassword, string userAddress, string userPhone)
        {
            UserEmail = userEmail;
            UserName = userName;
            UserSurname = userSurname;
            UserLogin = userLogin;
            UserPassword = userPassword;
            UserAddress = userAddress;
            UserPhone = userPhone;
        }
        void RegisterNewUser()
        {
            Console.Clear();
            Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
            Console.Write("Введите свою фамилию: ");
            string userSurname = Console.ReadLine();
            Console.Write("Введите свое имя: ");
            string userName = Console.ReadLine();
            Console.Write("Введите свою фамилию: ");

        }
        string ValidationInputEmail()
        {
            string userEmail = string.Empty;
            //Console.WriteLine("Введите ваш email");
            //if (Regex.Match)
            return userEmail;
        }
        string ValidationInputPhone()
        {
            string userPhone = string.Empty;
            //Console.WriteLine("Введите ваш email");
            //if (Regex.Match)
            return userPhone;
        }
        string ValidationInputLogin()
        {
            string userPhone = string.Empty;
            //Console.WriteLine("Введите ваш email");
            //if (Regex.Match)
            return userPhone;
        }
        string ValidationInputPassword()
        {
            string Password = string.Empty;
            //Console.WriteLine("Введите ваш email");
            //if (Regex.Match)
            return Password;
        }
        void UserChangeName()
        {

        }
        void UserChangeSurname()
        {

        }
        void UserChangeLogin()
        {

        }
        void UserChangePassword()
        {

        }
        void UserChangeAddress()
        {

        }
        void UserChangePhone()
        {

        }

    }
}