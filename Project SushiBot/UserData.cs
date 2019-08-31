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
        internal string Email { get; } = string.Empty;
        internal string Name { get; } = string.Empty;
        internal string Surname { get; } = string.Empty;
        internal string Login { get;} = string.Empty;
        internal string Password { get; } = string.Empty;
        internal UserData() { }
        internal UserData(string email, string name, string surname, string login, string password)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }
        //void RegisterNewUser()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
        //    Console.Write("Введите свою фамилию: ");
        //    string userSurname = Console.ReadLine();
        //    Console.Write("Введите свое имя: ");
        //    string userName = Console.ReadLine();
        //    Console.Write("Введите свою фамилию: ");

        //}
        //string ValidationInputEmail()
        //{
        //    string userEmail = string.Empty;
        //    //Console.WriteLine("Введите ваш email");
        //    //if (Regex.Match)
        //    return userEmail;
        //}
        //string ValidationInputPhone()
        //{
        //    string userPhone = string.Empty;
        //    //Console.WriteLine("Введите ваш email");
        //    //if (Regex.Match)
        //    return userPhone;
        //}
        //string ValidationInputLogin()
        //{
        //    string userPhone = string.Empty;
        //    //Console.WriteLine("Введите ваш email");
        //    //if (Regex.Match)
        //    return userPhone;
        //}
        //string ValidationInputPassword()
        //{
        //    string Password = string.Empty;
        //    //Console.WriteLine("Введите ваш email");
        //    //if (Regex.Match)
        //    return Password;
        //}
        //void UserChangePhone()
        //{

        //}

    }
}