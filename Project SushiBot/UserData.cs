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
    }
}