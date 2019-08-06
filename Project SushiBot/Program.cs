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
            PageProgram.PageRegisterNewUser(string.Empty, out int cursorPositionLeftInfo, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword);
            string userSurname = PageInput.InputSurname(cursorPositionLeftInfo, сursorPositionSurname);
            string userName = PageInput.InputName(cursorPositionLeftInfo, сursorPositionName);

            //Console.SetCursorPosition(50, 15);
            //Console.Write("Введите логин");
            //Console.SetCursorPosition(8, 15);
            //string userLogin = Console.ReadLine();
            //Console.SetCursorPosition(50, 15);
            //Console.Write("Принято        ");

            //Console.SetCursorPosition(50, 17);
            //Console.Write("Введите пароль");
            //Console.SetCursorPosition(11, 17);
            //string userPassword = Console.ReadLine();
            //Console.SetCursorPosition(50, 17);
            //Console.Write("Принято        ");

            //Console.SetCursorPosition(50, 19);
            //Console.Write("Повторите пароль");
            //Console.SetCursorPosition(21, 19);
            //string userRepeatPassword = Console.ReadLine();
            //Console.SetCursorPosition(50, 19);
            //Console.Write("Принято        ");

            Console.Read();
        }
    }
}
