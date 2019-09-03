using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class PageInput
    {
        private static readonly Logger logger = new Logger();
        internal static string InputRegistrationSurname(СursorPosition сursorPositionSurname)
        {
            logger.Info("Input surname", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionSurname.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите фамилию           ");
            Console.SetCursorPosition(сursorPositionSurname.Left, сursorPositionSurname.Top);
            string userSurname = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято                   ");
            return userSurname;
        }
        internal static string InputRegistrationName(СursorPosition сursorPositionName)
        {
            logger.Info("Input name", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionName.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите имя               ");
            Console.SetCursorPosition(сursorPositionName.Left, сursorPositionName.Top);
            string userName = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято                   ");
            return userName;
        }
        internal static string InputRegistrationEmail(СursorPosition сursorPositionEmail)
        {
            logger.Info("Input email", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionEmail.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите email             ");
            string userEmail = string.Empty;
            while (true)
            {
                string regexEmail = @"^[a-z0-9_\-\.]+@[a-z0-9_-]+\.[a-z]{2,6}$";
                Console.SetCursorPosition(сursorPositionEmail.Left, сursorPositionEmail.Top);
                userEmail = Console.ReadLine();
                if (!Regex.IsMatch(userEmail, regexEmail))
                {
                    Console.SetCursorPosition(сursorPositionEmail.Left, сursorPositionEmail.Top);
                    for (int i = 0; i < userEmail.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Не корректное значение    ");
                    continue;
                }
                if (UserDataRepository.GetUserDataByEmail(userEmail).Login.Equals(userEmail, StringComparison.Ordinal))
                {
                    Console.SetCursorPosition(сursorPositionEmail.Left, сursorPositionEmail.Top);
                    for (int i = 0; i < userEmail.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Такой email уже существует");
                }
                else
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято                   ");
                    break;
                }
            }
            return userEmail;
        }
        internal static string InputRegistrationLogin(СursorPosition сursorPositionLogin)
        {
            logger.Info("Input login", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionLogin.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите свой login         ");
            string userLogin = string.Empty;
            while (true)
            {
                Console.SetCursorPosition(сursorPositionLogin.Left, сursorPositionLogin.Top);
                userLogin = Console.ReadLine();
                if (UserDataRepository.GetUserDataByLogin(userLogin).Login.Equals(userLogin, StringComparison.Ordinal))
                {
                    Console.SetCursorPosition(сursorPositionLogin.Left, сursorPositionLogin.Top);
                    for (int i = 0; i < userLogin.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Такой login уже существует");
                }
                else
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято                   ");
                    break;
                }
            }

            return userLogin;
        }
        internal static string InputLogin(СursorPosition сursorPositionLogin)
        {
            logger.Info("Input login to enter", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionLogin.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите свой login         ");
            string userLogin = string.Empty;
            while (true)
            {
                Console.SetCursorPosition(сursorPositionLogin.Left, сursorPositionLogin.Top);
                userLogin = Console.ReadLine();
                if (UserDataRepository.GetUserDataByLogin(userLogin).Login.Equals(userLogin, StringComparison.Ordinal))
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято                   ");
                    break;
                }
                else
                {
                    Console.SetCursorPosition(сursorPositionLogin.Left, сursorPositionLogin.Top);
                    for (int i = 0; i < userLogin.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Нет такого login в Базе   ");
                }
            }
            return userLogin;
        }
        internal static string InputRegistrationPassword(СursorPosition сursorPositionPassword, СursorPosition сursorPositionRepeatPassword)
        {
            logger.Info("Input password", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionPassword.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите пароль               ");
            string userPassword = string.Empty;
            while (true)
            {
                string regexPassword = @"^(?=.*(\d))(?=.*(\p{L})).{6,}";
                Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                userPassword = Console.ReadLine();
                if (!Regex.IsMatch(userPassword, regexPassword))
                {
                    Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Не коректное значение. Пароль ");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 1);
                    Console.Write("должен иметь минимум одну циф-");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 2);
                    Console.Write("ру и букву, но не менее шести ");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 3);
                    Console.Write("символов");
                }
                else
                {
                    Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        Console.Write("*");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято                       ");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 1);
                    Console.Write("                              ");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 2);
                    Console.Write("                              ");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top + 3);
                    Console.Write("                              ");
                    if (InputRegistrationRepeatPassword(сursorPositionRepeatPassword, userPassword))
                    {
                        break;
                    }

                }
            }

            return userPassword;
        }
        internal static void InputPassword(СursorPosition сursorPositionPassword, string userLogin)
        {
            logger.Info("Input password to enter", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionPassword.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите пароль               ");
            string userPassword = string.Empty;
            while (true)
            {
                Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                userPassword = Console.ReadLine();
                if (UserDataRepository.GetUserDataByLogin(userLogin).Password.Equals(userPassword, StringComparison.Ordinal))
                {
                    Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        Console.Write("*");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято                      ");
                    break;
                }
                else
                {
                    Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Неверный пароль              ");
                }
            }
        }
        internal static bool InputRegistrationRepeatPassword(СursorPosition сursorPositionRepeatPassword, string userPassword)
        {
            logger.Info("Input repeat password", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionRepeatPassword.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Повторите пароль             ");
            Console.SetCursorPosition(сursorPositionRepeatPassword.Left, сursorPositionRepeatPassword.Top);
            string userRepeatPassword = Console.ReadLine();
            if (userPassword.Equals(userRepeatPassword, StringComparison.Ordinal))
            {
                Console.SetCursorPosition(сursorPositionRepeatPassword.Left, сursorPositionRepeatPassword.Top);
                for (int i = 0; i < userRepeatPassword.Length; i++)
                {
                    Console.Write("*");
                }
                Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                Console.Write("Принято                      ");
                return true;
            }
            else
            {
                Console.SetCursorPosition(сursorPositionRepeatPassword.Left, сursorPositionRepeatPassword.Top);
                for (int i = 0; i < userRepeatPassword.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                Console.Write("Неверно, попробуйте снова    ");
                return false;
            }
        }
        internal static string InputStreet(СursorPosition сursorPositionStreet)
        {
            logger.Info("Input street", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionStreet.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите улицу         ");
            Console.SetCursorPosition(сursorPositionStreet.Left, сursorPositionStreet.Top);
            string userStreet = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято               ");
            return userStreet;
        }
        internal static string InputHouse(СursorPosition сursorPositionHouse)
        {
            logger.Info("Input house", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionHouse.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер дома    ");
            Console.SetCursorPosition(сursorPositionHouse.Left, сursorPositionHouse.Top);
            string userHouse = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято               ");
            return userHouse;
        }
        internal static string InputApartment(СursorPosition сursorPositionApartment)
        {
            logger.Info("Input apartment", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionApartment.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер квартиры");
            Console.SetCursorPosition(сursorPositionApartment.Left, сursorPositionApartment.Top);
            string userApartment = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято               ");
            return userApartment;
        }
        internal static string InputPhone(СursorPosition сursorPositionPhone)
        {
            logger.Info("Input phone", Thread.CurrentThread);
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionPhone.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер телефона");
            string userPhone = string.Empty;
            while (true)
            {
                string regexPhone = @"^(17|29|33|44)[0-9]{7}$";
                Console.SetCursorPosition(сursorPositionPhone.Left, сursorPositionPhone.Top);
                userPhone = Console.ReadLine();
                if (!Regex.IsMatch(userPhone, regexPhone))
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Не корректное значение");
                    Console.SetCursorPosition(сursorPositionPhone.Left, сursorPositionPhone.Top);
                    for (int i = 0; i < userPhone.Length; i++)
                    {
                        Console.Write(" ");
                    }
                    continue;
                }
                else
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Принято               ");
                    break;
                }
            }
            return userPhone;
        }
        internal static int InputAmount(СursorPosition сursorPositionAmount)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(PageProgram.CursorPositionLeftInfo, сursorPositionAmount.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите Количество  ");
            int intAmount = 0;
            while (true)
            {
                Console.SetCursorPosition(сursorPositionAmount.Left, сursorPositionAmount.Top);
                string Amount = Console.ReadLine();
                if (int.TryParse(Amount, out intAmount) && intAmount >= 0)
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Некоректное значение");
                }
            }
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            if (intAmount > 0)
            {
                Console.Write("Добавлено корзину   ");
            }
            else
            {
                intAmount = 0;
                Console.Write("                    ");
            }
            return intAmount;
        }
    }
}
