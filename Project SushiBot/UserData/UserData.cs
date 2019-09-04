using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserData : IDisposable
    {
        internal string Email { get;set; } = string.Empty;
        internal string Name { get; set; } = string.Empty;
        internal string Surname { get; set; } = string.Empty;
        internal string Login { get; set; } = string.Empty;
        internal string Password { get; set; } = string.Empty;

        internal UserData() { }
        internal UserData(string email, string name, string surname, string login, string password)
        {
            Email = email;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
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
                Email = null;
                Name = null;
                Surname = null;
                Login = null;
                Password = null;
            }
        }
        ~UserData()
        {
            Dispose(false);
        }
    }
}