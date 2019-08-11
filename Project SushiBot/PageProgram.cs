using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class PageProgram
    {
        internal static void PageGreeting(string advertising, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует СУШИБОТ");
            Console.WriteLine("Мы представляет ресторан суши с бесплатной доставкой на дом\n");
            Console.WriteLine("Если вы являетесь ценителем японской кухни, то не откажите себе в удовольствии \nи заказать вкуснейшие суши в Минске. На нашем сайте вы найдете широкий ассорти-\nмент роллов и сетов на любой вкус.  Все они сделаны из свежих продуктов и нату-\nральных ингредиентов. Над приготовлением работают настоящие мастера своего дела\nСуши - это оптимальный вариант правильного питания,  ведь каждый сет – это сба-\nлансированный состав медленных углеводов, белка и клетчатки.Фамилия:\n");
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageGreetingBottom(СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Войти под своим логином");
            Console.WriteLine("TAB - Зарегестрироваться");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("SPACEBAR - Новости");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Выйти из программы");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumInput.Enter;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Exit;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumInput.SignUp;
                    }
                case ConsoleKey.Spacebar:
                    {
                        return EnumInput.News;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageUserSingUp(string advertising, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно входа пользователя пользователя");
            Console.WriteLine("Введите свой логин и пароль в форму\n");
            Console.WriteLine("Login:\n");
            сursorPositionLogin = new СursorPosition(8, 9);
            Console.WriteLine("Password:\n");
            сursorPositionPassword = new СursorPosition(11, 11);
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageUserSingUpBottom(СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            //Метод повторяется с PageRegisterNewUserBottom
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Принять форму");
            Console.WriteLine("DELETE - Сбросить форму");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumInput.Enter;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Back;
                    }
                case ConsoleKey.Delete:
                    {
                        return EnumInput.Reset;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageRegisterNewUser(string advertising, out int CursorPositionLeftInfo, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            CursorPositionLeftInfo = 50;
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
            Console.WriteLine("Ниже расположена форма которую необходимо заполнить\n");
            Console.WriteLine("Фамилия:\n");
            сursorPositionSurname = new СursorPosition(9, 9);
            Console.WriteLine("Имя:\n");
            сursorPositionName = new СursorPosition(5, 11);
            Console.WriteLine("Email*:\n");
            сursorPositionEmail = new СursorPosition(8, 13);
            Console.WriteLine("Login*:\n");
            сursorPositionLogin = new СursorPosition(8, 15);
            Console.WriteLine("Password*:\n");
            сursorPositionPassword = new СursorPosition(11, 17);
            Console.WriteLine("Повторите Password*:\n");
            сursorPositionRepeatPassword = new СursorPosition(21, 19);
            Console.WriteLine("Поля отмеченые * обязательны для заполнения");
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageRegisterNewUserBottom(СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Принять форму");
            Console.WriteLine("DELETE - Сбросить форму");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumInput.Enter;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Back;
                    }
                case ConsoleKey.Delete:
                    {
                        return EnumInput.Reset;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageNews(string advertising, UserData userData, string newsTitle, string newsText, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            string pageTitle = "Новости";
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            newsText = "Многие любители японской кухни задаются вопросом, что такое нори. Используются \nнори для суши в классической японской кухне, при приготовлении роллов. Это спе-\nциальные водоросли, в которые заворачивают рыбу, рис и прочие ингредиенты. При \nэтом важно понимать, что нори представляют собой натуральный продукт, полностью\nбезопасный и очень полезный для организма человека. Как правило, такие водорос-\nли используются при приготовлении большинства суши и роллов любого вида. Но все\nингредиенты должны быть отменного качества, только в таком случае гарантиру-\nется уникальный вкус и свойства японского блюда\n";
            newsTitle = "НОРИ ДЛЯ СУШИ\n";
            Console.WriteLine(advertising);
            Console.WriteLine("Вы вошли в акаунт. Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine(pageTitle);
            Console.WriteLine(newsTitle);
            Console.WriteLine(newsText);
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal static void PageNews(string advertising, string newsTitle, string newsText, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            string pageTitle = "Новости";
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            newsText = "Многие любители японской кухни задаются вопросом, что такое нори. Используются \nнори для суши в классической японской кухне, при приготовлении роллов. Это спе-\nциальные водоросли, в которые заворачивают рыбу, рис и прочие ингредиенты. При \nэтом важно понимать, что нори представляют собой натуральный продукт, полностью\nбезопасный и очень полезный для организма человека. Как правило, такие водорос-\nли используются при приготовлении большинства суши и роллов любого вида. Но все\nингредиенты должны быть отменного качества, только в таком случае гарантиру-\nется уникальный вкус и свойства японского блюда\n";
            newsTitle = "НОРИ ДЛЯ СУШИ\n";
            Console.WriteLine(advertising);
            Console.WriteLine(pageTitle);
            Console.WriteLine(newsTitle);
            Console.WriteLine(newsText);
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageNewsBottom(int indexNews, int indexMaxNews, СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            string nextNews = "Стрелка влево - Следующая новость";
            string prewNews = "Стрелка вправо - Предыдущая новость";
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            if (indexNews == 0)
            {
                nextNews = string.Empty;
            }
            else if (indexNews == indexMaxNews)
            {
                prewNews = string.Empty;
            }
            Console.WriteLine(nextNews);
            Console.WriteLine(prewNews);
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Открыть ссылку в браузере");
            //Process.Start("E:\\LearnWeb\\start.html"); запись файла  и Запуск ссылки сделать
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return indexNews == indexMaxNews ? EnumInput.None : EnumInput.Previous;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return indexNews == 0 ? EnumInput.None : EnumInput.Following;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumInput.OpenBrowser;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Back;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageProfile(string advertising, UserData userData, string titleStock, string textStock, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            titleStock = "АКЦИЯ - Летнее комбо от SUSHI BOT";
            textStock = "Когда хочется всего и сразу. Выбери одну из 4-х комбинаций роллов, добавь один \nиз десертов на выбор и не забудь про напиток. Зеленый чай с цитрусом или черный\nчай с лесными ягодами. И это все по супер цене - всего за 29.90р.\n*комбо предложение не суммируется с другими скидками, дисконтами или акционными\n предложениями.\n";
            Console.WriteLine(advertising);
            Console.WriteLine("Вы вошли в акаунт. Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine(titleStock);
            Console.WriteLine(textStock);
            Console.WriteLine("Сдесь вы можете узнать о наших актуальных акциях, заказать суши с доставкой,  \nпроверить статус своих заказов, просмотреть новости.");
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageProfileBottom(int indexStock, int indexMaxStocks, СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            string nextStock = "Стрелка влево - Следующая Акция";
            string prewStock = "Стрелка вправо - Предыдущая Акция";
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            if (indexStock == 0)
            {
                nextStock = string.Empty;
            }
            else if (indexStock == indexMaxStocks)
            {
                prewStock = string.Empty;
            }
            Console.WriteLine(nextStock);
            Console.WriteLine(prewStock);
            Console.WriteLine("ENTER - Заказать суши");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("TAB - Проверить статус заказа");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("SPACEBAR - Новости");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top + 2);
            Console.WriteLine("ESC - Выйти из профиля");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return indexStock == indexMaxStocks ? EnumInput.None : EnumInput.Previous;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return indexStock == 0 ? EnumInput.None : EnumInput.Following;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumInput.OpenOrder;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumInput.OpenStatus;
                    }
                case ConsoleKey.Spacebar:
                    {
                        return EnumInput.News;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Back;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageStatusOrder(string advertising, UserData userData, OrderData orderInfo, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.WriteLine(advertising);
            Console.WriteLine("Вы вошли в акаунт. Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine("Тут вы можете узнать статус ваших заказав, а так же посмотреть историю заказов\n");
            orderInfo.OrderDataWrite();
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        internal EnumInput PageStatusOrder(int indexOrder, int indexMaxOrders, СursorPosition сursorPositionInputInfoLeft, СursorPosition сursorPositionInputInfoRight)
        {
            string nextOrder = "Стрелка влево - Следующая заказ";
            string prewOrder = "Стрелка вправо - Предыдущий заказ";
            Console.SetCursorPosition(сursorPositionInputInfoLeft.Left, сursorPositionInputInfoLeft.Top);
            if (indexOrder == 0)
            {
                nextOrder = string.Empty;
            }
            else if (indexOrder == indexMaxOrders)
            {
                prewOrder = string.Empty;
            }
            Console.WriteLine(nextOrder);
            Console.WriteLine(prewOrder);
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Обновить статус");
            Console.SetCursorPosition(сursorPositionInputInfoRight.Left, сursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return indexOrder == indexMaxOrders ? EnumInput.None : EnumInput.Previous;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return indexOrder == 0 ? EnumInput.None : EnumInput.Following;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumInput.Refresh;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumInput.Back;
                    }
                default:
                    {
                        return EnumInput.None;
                    }
            }
        }
        internal static void PageOrderSushi(string advertising, UserData userData, int indexMenuNow, Product product, out СursorPosition сursorPositionInputAmount, out СursorPosition сursorPositionInputInfoLeft, out СursorPosition сursorPositionInputInfoRight)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.WriteLine(advertising);
            Console.WriteLine("Вы вошли в акаунт. Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            string[] menu = new string[9] { "Сеты", "Маки", "Урамаки", "Футомаки", "Десерты", "Нигири", "Гунканы", "Супы", "Напитки" };
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Меню");
            int prevMenu = indexMenuNow == 0 ? menu.Length - 1 : indexMenuNow - 1;
            int nextMenu = indexMenuNow == menu.Length - 1 ? 0 : indexMenuNow + 1;
            Console.Write(menu[(int)prevMenu]);
            Console.SetCursorPosition(15, 8);
            Console.Write(" <-- " + menu[indexMenuNow] + " --> ");
            Console.SetCursorPosition(22, 8);
            Console.Write(menu[indexMenuNow]);
            Console.SetCursorPosition(32, 8);
            Console.Write(" --> ");
            Console.SetCursorPosition(32, 8);
            Console.Write(menu[(int)nextMenu]);
            product.ProductDataWrite();
            Console.Write("Количество: ");
            сursorPositionInputAmount = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write(product.Amount);
            сursorPositionInputInfoLeft = new СursorPosition(0, 23);
            сursorPositionInputInfoRight = new СursorPosition(40, 23);
        }
        //internal static void PageMenuSushi(int indexMenuNow)
        //{
        //    string[] menu = new string[9] { "Сеты", "Маки", "Урамаки", "Футомаки", "Десерты", "Нигири", "Гунканы", "Супы", "Напитки" };
        //    Console.SetCursorPosition(20, 7);
        //    Console.WriteLine("Меню");
        //    int prevMenu = indexMenuNow == 0 ? menu.Length - 1 : indexMenuNow - 1;
        //    int nextMenu = indexMenuNow == menu.Length - 1 ? 0 : indexMenuNow + 1;
        //    Console.Write(menu[(int)prevMenu]);
        //    Console.SetCursorPosition(15, 8);
        //    Console.Write(" <-- " + menu[indexMenuNow] + " --> ");
        //    Console.SetCursorPosition(22, 8);
        //    Console.Write(menu[indexMenuNow]);
        //    Console.SetCursorPosition(32, 8);
        //    Console.Write(" --> ");
        //    Console.SetCursorPosition(32, 8);
        //    Console.Write(menu[(int)nextMenu]);
        //}
    }
    class PageInput
    {
        internal static string InputSurname(int cursorPositionLeftInfo, СursorPosition сursorPositionSurname)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionSurname.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите фамилию");
            Console.SetCursorPosition(сursorPositionSurname.Left, сursorPositionSurname.Top);
            string userSurname = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userSurname;
        }
        internal static string InputName(int cursorPositionLeftInfo, СursorPosition сursorPositionName)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionName.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите имя");
            Console.SetCursorPosition(сursorPositionName.Left, сursorPositionName.Top);
            string userName = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userName;
        }
        internal static string InputEmail(int cursorPositionLeftInfo, СursorPosition сursorPositionEmail)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionEmail.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите email");
            //считывание емалов с базы
            string[] basaEmail = new string[5] { "samynchik@mail.com", "kc29hc0e@yandex.ru", "myrfqpb@mail.ru", "copaa6@gmail.com", "xl9bc5@gmail.com" };
            string userEmail = string.Empty;
            while (true)
            {
                string regexEmail = @"^[a-z0-9_-]+@[a-z0-9_-]+\.[a-z]{2,6}$";
                Console.SetCursorPosition(сursorPositionEmail.Left, сursorPositionEmail.Top);
                userEmail = Console.ReadLine();                
                if (!Regex.IsMatch(userEmail,regexEmail))
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Не коректное значение");
                    continue;
                }
                int j = 0;
                for (int i = 0; i < basaEmail.Length; i++)
                {
                    if (basaEmail[i].Equals(userEmail,StringComparison.OrdinalIgnoreCase))
                    {
                        Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                        Console.Write("Такой email уже существует");
                        break;
                    }
                    j++;
                }
                if (j == basaEmail.Length)
                {
                    break;
                }
            }
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userEmail;
        }
        internal static string InputLogin(int cursorPositionLeftInfo, СursorPosition сursorPositionLogin)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionLogin.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите свой login");
            //считывание логинов с базы
            string[] basaLogin = new string[5] { "samyn", "yandex", "komaro", "Vasia", "Valera" };
            string userLogin = string.Empty;
            while (true)
            {
                Console.SetCursorPosition(сursorPositionLogin.Left, сursorPositionLogin.Top);
                userLogin = Console.ReadLine();
                int j = 0;
                for (int i = 0; i < basaLogin.Length; i++)
                {
                    if (basaLogin[i].Equals(userLogin, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                        Console.Write("Такой login уже существует");
                        break;
                    }
                    j++;
                }
                if (j == basaLogin.Length)
                {
                    break;
                }
            }
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userLogin;
        }
        internal static string InputPassword(int cursorPositionLeftInfo, СursorPosition сursorPositionPassword, СursorPosition сursorPositionRepeatPassword)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionPassword.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите пароль");
            string userPassword = string.Empty;
            while (true)
            {
                string regexPassword = @"^(?=.*(\d))(?=.*(\p{L})).{6,}";
                Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                userPassword = Console.ReadLine();
                Console.SetCursorPosition(сursorPositionPassword.Left, сursorPositionPassword.Top);
                for (int i = 0; i < userPassword.Length; i++)
                {
                    Console.Write("*");
                }
                if (!Regex.IsMatch(userPassword, regexPassword))
                {
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                    Console.Write("Не коректное значение. Пароль");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top-1);
                    Console.Write("должен иметь минимум одну циф-");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top - 2);
                    Console.Write("ру и букву, но не менее шести");
                    Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top - 3);
                    Console.Write("символов");
                }
                else
                {
                    if (InputRepeatPassword(cursorPositionLeftInfo, сursorPositionRepeatPassword, userPassword))
                    {
                        break;
                    }
                    
                }
            }
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top - 1);
            Console.Write("                             ");
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top - 2);
            Console.Write("                             ");
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top - 3);
            Console.Write("           ");
            return userPassword;
        }
        internal static bool InputRepeatPassword(int cursorPositionLeftInfo, СursorPosition сursorPositionRepeatPassword,string userPassword)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionRepeatPassword.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Повторите пароль");
            Console.SetCursorPosition(сursorPositionRepeatPassword.Left, сursorPositionRepeatPassword.Top);
            string userRepeatPassword = Console.ReadLine();
            for (int i = 0; i < userRepeatPassword.Length; i++)
            {
                Console.Write("*");
            }
            if (userPassword.Equals(userRepeatPassword, StringComparison.Ordinal))
            {
                Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                Console.Write("Принято        ");
                return true;
            }
            else
            {
                Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
                Console.Write("Неверно, попробуйте снова");
                return false;
            }
        }
    }
    class AdvertisingsBanner
    {
        internal string[] Banners { get; }
        internal AdvertisingsBanner(string[] Banners)
        {
            this.Banners = Banners;
        }
        internal string RandomBanner()
        {
            Random random = new Random();
            return Banners[random.Next(0, Banners.Length)];
        }
    }
    internal struct СursorPosition
    {
        internal int Left { get; set; }
        internal int Top { get; set; }
        internal СursorPosition(int left, int top)
        {
            Left = left;
            Top = top;
        }
           
    }
}
