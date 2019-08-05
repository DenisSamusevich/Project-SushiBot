using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            string advertising = "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
            Console.WriteLine("Ниже расположена форма которую необходимо заполнить\n");
            Console.WriteLine("Фамилия:\n");
            Console.WriteLine("Имя:\n");
            Console.WriteLine("Email*:\n");
            Console.WriteLine("Login*:\n");
            Console.WriteLine("Password*:\n");
            Console.WriteLine("Повторите Password*:\n");
            Console.WriteLine("Поля отмеченые * обязательны для заполнения");

            Console.SetCursorPosition(50, 9);
            Console.Write("Введите фамилию");
            Console.SetCursorPosition(9, 9);
            string userSurname = Console.ReadLine();
            Console.SetCursorPosition(50, 9);
            Console.Write("Принято        ");

            Console.SetCursorPosition(50, 11);
            Console.Write("Введите имя");
            Console.SetCursorPosition(5,11);
            string userName = Console.ReadLine();
            Console.SetCursorPosition(50, 11);
            Console.Write("Принято        ");

            Console.SetCursorPosition(50, 13);
            Console.Write("Введите email");
            Console.SetCursorPosition(8, 13);
            string userEmail = Console.ReadLine();
            Console.SetCursorPosition(50, 13);
            Console.Write("Принято        ");

            Console.SetCursorPosition(50, 15);
            Console.Write("Введите логин");
            Console.SetCursorPosition(8, 15);
            string userLogin = Console.ReadLine();
            Console.SetCursorPosition(50, 15);
            Console.Write("Принято        ");

            Console.SetCursorPosition(50, 17);
            Console.Write("Введите пароль");
            Console.SetCursorPosition(11, 17);
            string userPassword = Console.ReadLine();
            Console.SetCursorPosition(50, 17);
            Console.Write("Принято        ");

            Console.SetCursorPosition(50, 19);
            Console.Write("Повторите пароль");
            Console.SetCursorPosition(21, 19);
            string userRepeatPassword = Console.ReadLine();
            Console.SetCursorPosition(50, 19);
            Console.Write("Принято        ");

            Console.Read();
        }
    }
}
