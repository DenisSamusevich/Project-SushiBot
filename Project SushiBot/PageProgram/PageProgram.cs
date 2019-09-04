using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    static class PageProgram
    {
        static СursorPosition CursorPositionInputInfoLeft { get; } = new СursorPosition(0, 23);
        static СursorPosition CursorPositionInputInfoRight { get; } = new СursorPosition(40, 23);
        internal static int CursorPositionLeftInfo { get; } = 50;
        internal static void PageGreeting(string advertising)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует СУШИБОТ");
            Console.WriteLine("Мы представляет ресторан суши с бесплатной доставкой на дом\n");
            Console.WriteLine("Если вы являетесь ценителем японской кухни, то не откажите себе в удовольствии \nи заказать вкуснейшие суши в Минске. На нашем сайте вы найдете широкий ассорти-\nмент роллов и сетов на любой вкус.  Все они сделаны из свежих продуктов и нату-\nральных ингредиентов. Над приготовлением работают настоящие мастера своего дела\nСуши - это оптимальный вариант правильного питания,  ведь каждый сет – это сба-\nлансированный состав медленных углеводов, белка и клетчатки.\n");
        }
        internal static EnumPage PageGreetingBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Войти под своим логином");
            Console.WriteLine("TAB - Зарегестрироваться");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Выйти из программы");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.PageLogin;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.Exit;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.PageRegisterNewUser;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageUserLogin(string advertising, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно входа пользователя пользователя");
            Console.WriteLine("Введите свой логин и пароль в форму\n");
            Console.Write("Login: ");
            сursorPositionLogin = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
            Console.Write("Password: ");
            сursorPositionPassword = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.WriteLine("\n");
        }
        internal static EnumPage PageUserLoginBottom()
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
                        return EnumPage.PageGreeting;
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
            Console.WriteLine();
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
                        return EnumPage.PageGreeting;
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
        internal static void PageNews(string advertising, UserData userData, NewsData newsData)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
            newsData.WriteNews();
            newsData.Dispose();
            userData.Dispose();
        }
        internal static EnumPage PageNewsBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("Стрелка влево - Следующая новость");
            Console.WriteLine("Стрелка вправо - Предыдущая новость");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Открыть ссылку в браузере");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return EnumPage.PrevNews;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return EnumPage.NextNews;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.OpenBrowser;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.PageProfile;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageProfile(string advertising, UserData userData)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
            Console.WriteLine("Специалисты в области диетологии считают суши хорошо сбалансированной, здоровой\nпищей, так как в них содержится много питательных веществ, в том числе минералы\nи витамины, которые, как правило, частично теряются в процессе кулинарной\nобработки.");
            Console.WriteLine("Рыба и морепродукты малокалорийны: калорий в них меньше, чем даже в самом нежи-\nрном курином и любом другом мясе.Они обеспечивают организм высококачественными \nбелками и минералами - йод, цинк, калий, фосфор.Рыба и морепродукты также бога-\nты витаминами группы В. Жирные кислоты омега - 3, входящие в состав рыбьего жи-\nра очень полезны для сердечно - сосудистой системы.Они предотвращают образо-\nвание тромбов, сужение просвета артерий и снижают риск сердечных приступов.\n");
            Console.WriteLine("Сдесь вы можете узнать о наших актуальных акциях, заказать суши с доставкой,  \nпроверить статус своих заказов, просмотреть новости.\n");
            userData.Dispose();
        }
        internal static EnumPage PageProfileBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Заказать суши");
            Console.WriteLine("TAB - Проверить статус заказа");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("SPACEBAR - Новости");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Выйти из профиля");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.PageOrderSushi;
                    }
                case ConsoleKey.Tab:
                    {
                        return EnumPage.PageStatusOrder;
                    }
                case ConsoleKey.Spacebar:
                    {
                        return EnumPage.PageNews;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.PageGreeting;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageStatusOrder(string advertising, UserData userData, ProductOrderData orderInfo)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
            Console.WriteLine("Тут вы можете узнать статус ваших заказов, а так же посмотреть историю заказов\n");
            if (orderInfo == null)
            {
                Console.WriteLine("У вас еще не было ни одного заказа");
            }
            else
            {
                orderInfo.OrderDataWrite();
            }
            userData.Dispose();
        }
        internal static EnumPage PageStatusOrderBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("Стрелка влево - Следующая заказ");
            Console.WriteLine("Стрелка вправо - Предыдущий заказ");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("SPACEBAR - Обновить статус");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 1);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        return EnumPage.PrevOrder;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        return EnumPage.NextOrder;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Reset;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.PageProfile;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageOrderSushi(string advertising, UserData userData, string[] menu,ref int indexMenuNow, ProductInfoData product, out СursorPosition сursorPositionInputAmount)
        {
            if(indexMenuNow==menu.Length)
            {
                indexMenuNow = 0;
            }
            else if (indexMenuNow==-1)
            {
                indexMenuNow = menu.Length - 1;
            }
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
            Console.SetCursorPosition(16, 7);
            Console.WriteLine("Меню");
            int prevMenu = indexMenuNow == 0 ? menu.Length - 1 : indexMenuNow - 1;
            int nextMenu = indexMenuNow == menu.Length - 1 ? 0 : indexMenuNow + 1;
            Console.Write(menu[prevMenu]);
            Console.SetCursorPosition(10, 8);
            Console.Write(" <-- " + menu[indexMenuNow] + " --> ");
            Console.SetCursorPosition(28, 8);
            Console.Write(menu[nextMenu]);
            Console.WriteLine("\n");
            product.ProductDataWrite();
            Console.Write("Укажите количество: ");
            сursorPositionInputAmount = new СursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write(0.ToString());
            userData.Dispose();
        }
        internal static EnumPage PageOrderSushiBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("Стрелка влево - Следующий раздел");
            Console.WriteLine("Стрелка вправо - Предыдущий раздел");
            Console.WriteLine("Стрелка вниз - Следующий продукт");
            Console.WriteLine("Стрелка вверх - Предыдущий продукт");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ENTER - Указать количество");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top+1);
            Console.WriteLine("TAB - Оформить заказ");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top + 2);
            Console.WriteLine("ESC - Вернуться в предыдущее меню\n");
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
                case ConsoleKey.Tab:
                    {
                        return EnumPage.PageRegistrationOrder;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.PageProfile;
                    }
                case ConsoleKey.Enter:
                    {
                        return EnumPage.Amount;
                    }
                default:
                    {
                        return EnumPage.None;
                    }
            }
        }
        internal static void PageRegistrationOrder(string advertising, UserData userData, ProductOrderData orderInfo)
        {
            PageClear();
            Console.WriteLine(advertising);
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
            Console.WriteLine("Тут вы можете подтвердить список заказаных суши и оформить доставку\n");
            orderInfo.OrderDataPriceWrite();
            userData.Dispose();
        }
        internal static EnumPage PageRegistrationOrderBottom()
        {
            Console.SetCursorPosition(CursorPositionInputInfoLeft.Left, CursorPositionInputInfoLeft.Top);
            Console.WriteLine("ENTER - Оформить заказ");
            Console.SetCursorPosition(CursorPositionInputInfoRight.Left, CursorPositionInputInfoRight.Top);
            Console.WriteLine("ESC - Сбросить заказ");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.Enter:
                    {
                        return EnumPage.PageOrderEnd;
                    }
                case ConsoleKey.Escape:
                    {
                        return EnumPage.PageProfile;
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
            Console.WriteLine("Добрый день {0} {1}\n", userData.Name, userData.Surname);
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
            userData.Dispose();
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
                        return EnumPage.PageRegistrationOrder;
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
            Console.WriteLine(infoSystem);
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.WriteLine("Нажмите Enter для продолжения");
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
        internal static void PageClear()
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
        }
    }

}
