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
        string UserEmail { get; } = string.Empty;
        internal string UserName { get; } = string.Empty;
        internal string UserSurname { get; } = string.Empty;
        string UserLogin { get;} = string.Empty;
        string UserPassword { get; set; } = string.Empty;


        UserData(string userEmail, string userName, string userSurname, string userLogin, string userPassword)
        {
            UserEmail = userEmail;
            UserName = userName;
            UserSurname = userSurname;
            UserLogin = userLogin;
            UserPassword = userPassword;
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
        void UserChangePhone()
        {

        }

    }
}