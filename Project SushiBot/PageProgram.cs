using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    static class PageProgram
    {
        static СursorPosition CursorPositionInputInfoLeft { get; } = new СursorPosition(0, 23);
        static СursorPosition CursorPositionInputInfoRight { get; } = new СursorPosition(40, 23);
        static int CursorPositionLeftInfo { get; } = 50;
        internal static void PageGreeting(string advertising)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует СУШИБОТ");
            Console.WriteLine("Мы представляет ресторан суши с бесплатной доставкой на дом\n");
            Console.WriteLine("Если вы являетесь ценителем японской кухни, то не откажите себе в удовольствии \nи заказать вкуснейшие суши в Минске. На нашем сайте вы найдете широкий ассорти-\nмент роллов и сетов на любой вкус.  Все они сделаны из свежих продуктов и нату-\nральных ингредиентов. Над приготовлением работают настоящие мастера своего дела\nСуши - это оптимальный вариант правильного питания,  ведь каждый сет – это сба-\nлансированный состав медленных углеводов, белка и клетчатки.Фамилия:\n");
        }
        internal static EnumPage PageGreetingBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Войти под своим логином");
            Console.WriteLine("TAB - Зарегестрироваться");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Выйти из программы");
            //Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            //Console.WriteLine("SPACEBAR - Новости");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.LogIn;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Exit;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.RegisterNewUser;
                    }
                //case ConsoleKey.Spacebar:
                //    {
                //        return EnumInput.News;
                //    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageUserLogIn(string advertising, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно входа пользователя пользователя");
            Console.WriteLine("Введите свой логин и пароль в форму\n");
            Console.WriteLine("Login: ");
            сursorPositionLogin = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("Password: ");
            сursorPositionPassword = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
        }
        internal static EnumPage PageUserLogInBottom()
        {
            //Метод повторяется с PageRegisterNewUserBottom
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Принять форму");
            Console.WriteLine("DELETE - Сбросить форму");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Accept;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Greeting;
                    }
                case ConsoleKey.Delete:
                    {
                        return EnumPage.Reset;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageRegisterNewUser(string advertising, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
            Console.WriteLine("Ниже расположена форма которую необходимо заполнить\n");
            Console.Write("Фамилия: ");
            сursorPositionSurname = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Имя: ");
            сursorPositionName = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Email*: ");
            сursorPositionEmail = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Login*: ");
            сursorPositionLogin = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Password*: ");
            сursorPositionPassword = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Повторите Password*: ");
            сursorPositionRepeatPassword = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("Поля отмеченые * обязательны для заполнения");
        }
        internal static EnumPage PageRegisterNewUserBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Принять форму");
            Console.WriteLine("DELETE - Сбросить форму");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Accept;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Greeting;
                    }
                case ConsoleKey.Delete:
                    {
                        return EnumPage.Reset;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageNews(string advertising, UserData userData, string newsTitle, string newsText) //Подправиь новости
        {
            PageClear();
            newsText = "Многие любители японской кухни задаются вопросом, что такое нори. Используются \nнори для суши в классической японской кухне, при приготовлении роллов. Это спе-\nциальные водоросли, в которые заворачивают рыбу, рис и прочие ингредиенты. При \nэтом важно понимать, что нори представляют собой натуральный продукт, полностью\nбезопасный и очень полезный для организма человека. Как правило, такие водорос-\nли используются при приготовлении большинства суши и роллов любого вида. Но все\nингредиенты должны быть отменного качества, только в таком случае гарантиру-\nется уникальный вкус и свойства японского блюда\n";
            newsTitle = "НОРИ ДЛЯ СУШИ\n";
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine("Новости");
            Console.WriteLine(newsTitle);
            Console.WriteLine(newsText);
        }        
        //internal static void PageNews(string advertising, string newsTitle, string newsText)
        //{
        //    UserData userData = new UserData();
        //    PageNews(advertising, userData, newsTitle, newsText);
        //}
        internal static EnumPage PageNewsBottom(int indexNews, int indexMaxNews)
        {
            string nextNews = "Стрелка влево - Следующая новость";
            string prewNews = "Стрелка вправо - Предыдущая новость";
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
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
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Открыть ссылку в браузере");
            //Process.Start("E:\\LearnWeb\\start.html"); запись файла  и Запуск ссылки сделать
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return indexNews == indexMaxNews ? EnumPage.None : EnumPage.PrevNews;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return indexNews == 0 ? EnumPage.None : EnumPage.NextNews;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.OpenBrowser;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Profile;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageProfile(string advertising, UserData userData/*, string titleStock, string textStock*/)
        {
            PageClear();
            //titleStock = "АКЦИЯ - Летнее комбо от SUSHI BOT";
            //textStock = "Когда хочется всего и сразу. Выбери одну из 4-х комбинаций роллов, добавь один \nиз десертов на выбор и не забудь про напиток. Зеленый чай с цитрусом или черный\nчай с лесными ягодами. И это все по супер цене - всего за 29.90р.\n*комбо предложение не суммируется с другими скидками, дисконтами или акционными\n предложениями.\n";
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            //Console.WriteLine(titleStock);
            //Console.WriteLine(textStock);
            Console.WriteLine("Сдесь вы можете узнать о наших актуальных акциях, заказать суши с доставкой,  \nпроверить статус своих заказов, просмотреть новости.");
        }
        internal static EnumPage PageProfileBottom(int indexStock, int indexMaxStocks)
        {
            //string nextStock = "Стрелка влево - Следующая Акция";
            //string prewStock = "Стрелка вправо - Предыдущая Акция";
            //Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            //if (indexStock == 0)
            //{
            //    nextStock = string.Empty;
            //}
            //else if (indexStock == indexMaxStocks)
            //{
            //    prewStock = string.Empty;
            //}
            //Console.WriteLine(nextStock);
            //Console.WriteLine(prewStock);
            Console.WriteLine("ENTER - Заказать суши");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("TAB - Проверить статус заказа");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("SPACEBAR - Новости");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 2);
            Console.WriteLine("ESC - Выйти из профиля");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                //case ConsoleKey.RightArrow:
                //    {
                //        return indexStock == indexMaxStocks ? EnumInput.None : EnumInput.Previous;
                //    }
                //case ConsoleKey.LeftArrow:
                //    {
                //        return indexStock == 0 ? EnumInput.None : EnumInput.Following;
                //    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.OrderSushi;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.StatusOrder;
                    }
                case ConsoleKey.Spacebar:
                    {
                        return EnumPage.News;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Greeting;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageStatusOrder(string advertising, UserData userData, OrderData orderInfo)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine("Тут вы можете узнать статус ваших заказов, а так же посмотреть историю заказов\n");
            orderInfo.OrderDataWrite(true);
        }
        internal static EnumPage PageStatusOrderBottom(int indexOrder, int indexMaxOrders)
        {
            string nextOrder = "Стрелка влево - Следующая заказ";
            string prewOrder = "Стрелка вправо - Предыдущий заказ";
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
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
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Обновить статус");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return indexOrder == indexMaxOrders ? EnumPage.None : EnumPage.PrevOrder;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return indexOrder == 0 ? EnumPage.None : EnumPage.NextProduct;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Reset;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Profile;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageOrderSushi(string advertising, UserData userData, int indexMenuNow, Product product, out СursorPosition сursorPositionInputAmount)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
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
        }
        internal static EnumPage PageOrderSushiBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("Стрелка влево - Следующий раздел");
            Console.WriteLine("Стрелка вправо - Предыдущий раздел");
            Console.WriteLine("Стрелка вниз - Следующий продукт");
            Console.WriteLine("Стрелка вверх - Предыдущий продукт");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("TAB - Указать количество");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top+1);
            Console.WriteLine("ENTER - Оформить заказ");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 2);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return EnumPage.NextProduct;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return EnumPage.PrevProduct;
                    }
                case ConsoleKey.UpArrow:
                    {
                        return EnumPage.UpProduct;
                    }
                case ConsoleKey.DownArrow:
                    {
                        return EnumPage.DownProduct;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.RegistrationOrder;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Profile;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.Amount;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }

        }
        internal static void PageRegistrationOrder(string advertising, UserData userData, OrderData orderInfo)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine("Тут вы можете подтвердить список заказаных суши и оформить доставку\n");
            orderInfo.OrderDataWrite(false);
        }
        internal static EnumPage PageRegistrationOrderBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Оформить заказ");
            Console.WriteLine("ESC - Сбросить заказ и вернуться в предыдущее меню");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("TAB - Указать количество");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.OrderEnd;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.OrderSushi;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.Amount;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageOrderEnd(string advertising, UserData userData, out СursorPosition сursorPositionInputStreet, out СursorPosition сursorPositionInputHouse,out СursorPosition сursorPositionInputApartment,  out СursorPosition сursorPositionInputPhone)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.UserName, userData.UserSurname);
            Console.WriteLine("Ваш заказ сформирован, осталось только ввести адрес доставки и номер телефона.\n");
            Console.Write("Улица: ");
            сursorPositionInputStreet = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Дом: ");
            сursorPositionInputHouse = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Квартира: ");
            сursorPositionInputApartment = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Телефон: +375");
            сursorPositionInputPhone = new СursorPosition(Console.CursorLeft, Console.CursorTop);
        }
        internal static EnumPage PageOrderEndBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Принять форму");
            Console.WriteLine("DELETE - Сбросить форму");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Accept;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.RegistrationOrder;
                    }
                case ConsoleKey.Delete:
                    {
                        return EnumPage.Reset;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageInfo(string advertising, string infoSystem)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("\n\n\n");
            Console.SetCursorPosition(25, Console.CursorTop);
            Console.WriteLine(infoSystem);//"Вы успешно вошли в систему"  "Вы успешно зарегестрировались" "Заказ успешно оформлен"
            Console.SetCursorPosition(23, Console.CursorTop);
            Console.WriteLine("Нажмите Enter для продолжения");
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.Write('\u0008');
            }
        }
        internal static void PageClear()
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
        }
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
                    Console.Write("Не корректное значение");
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
        internal static string InputStreet(int cursorPositionLeftInfo, СursorPosition сursorPositionStreet)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionStreet.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите улицу");
            Console.SetCursorPosition(сursorPositionStreet.Left, сursorPositionStreet.Top);
            string userStreet = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userStreet;
        }
        internal static string InputHouse(int cursorPositionLeftInfo, СursorPosition сursorPositionHouse)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionHouse.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер дома");
            Console.SetCursorPosition(сursorPositionHouse.Left, сursorPositionHouse.Top);
            string userHouse = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userHouse;
        }
        internal static string InputApartment(int cursorPositionLeftInfo, СursorPosition сursorPositionApartment)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionApartment.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер квартиры");
            Console.SetCursorPosition(сursorPositionApartment.Left, сursorPositionApartment.Top);
            string userApartment = Console.ReadLine();
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userApartment;
        }
        internal static string InputPhone(int cursorPositionLeftInfo, СursorPosition сursorPositionPhone)
        {
            СursorPosition cursorPositionInfo = new СursorPosition(cursorPositionLeftInfo, сursorPositionPhone.Top);
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Введите номер своего телефона");
            Console.SetCursorPosition(сursorPositionPhone.Left, сursorPositionPhone.Top);
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
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.SetCursorPosition(cursorPositionInfo.Left, cursorPositionInfo.Top);
            Console.Write("Принято        ");
            return userPhone;
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
