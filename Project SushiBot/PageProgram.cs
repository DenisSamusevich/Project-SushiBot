using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class PageProgram
    {
        static void PageGreeting(string advertising)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            advertising =     "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует СУШИБОТ");
            Console.WriteLine("Мы представляет ресторан суши с бесплатной доставкой на дом\n");
            Console.WriteLine("Если вы являетесь ценителем японской кухни, то не откажите себе в удовольствии \nи заказать вкуснейшие суши в Минске. На нашем сайте вы найдете широкий ассорти-\nмент роллов и сетов на любой вкус.  Все они сделаны из свежих продуктов и нату-\nральных ингредиентов. Над приготовлением работают настоящие мастера своего дела\n Суши - это оптимальный вариант правильного питания, ведь каждый сет – это сба-\nлансированный состав медленных углеводов, белка и клетчатки.Фамилия:\n");
            Console.SetCursorPosition(23, 0);


            Console.SetCursorPosition(23, 40);

            Console.SetCursorPosition(24, 40);
            Console.WriteLine("ESC - выйти");
        }
        static void PageRegisterNewUser(string advertising, out СursorPosition сursorPositionSurname, out СursorPosition сursorPositionName, out СursorPosition сursorPositionEmail, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword, out СursorPosition сursorPositionRepeatPassword)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            advertising = "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно регистрации нового пользователя");
            Console.WriteLine("Ниже расположена форма которую необходимо заполнить\n");
            Console.WriteLine("Фамилия:\n");
            сursorPositionSurname = new СursorPosition(9,9);
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
            Console.WriteLine("ESC - вернуться в предыдущее меню");
        }
    }
    struct СursorPosition
    {
        int Left { get; set; }
        int Top { get; set; }
        internal СursorPosition(int left, int top)
        {
            Left = left;
            Top = top;
        }
           
    }
}
