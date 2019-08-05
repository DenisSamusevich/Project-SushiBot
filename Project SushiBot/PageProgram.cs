﻿using System;
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
            advertising = "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует СУШИБОТ");
            Console.WriteLine("Мы представляет ресторан суши с бесплатной доставкой на дом\n");
            Console.WriteLine("Если вы являетесь ценителем японской кухни, то не откажите себе в удовольствии \nи заказать вкуснейшие суши в Минске. На нашем сайте вы найдете широкий ассорти-\nмент роллов и сетов на любой вкус.  Все они сделаны из свежих продуктов и нату-\nральных ингредиентов. Над приготовлением работают настоящие мастера своего дела\nСуши - это оптимальный вариант правильного питания,  ведь каждый сет – это сба-\nлансированный состав медленных углеводов, белка и клетчатки.Фамилия:\n");
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("1 - Войти");
            Console.WriteLine("2 - Зарегестрироваться");
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("3 - Новости");
            Console.SetCursorPosition(40, 24);
            Console.WriteLine("ESC - Выйти");
        }
        static void PageUserSingUp(string advertising, out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword)
        {
            Console.Clear();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            advertising = "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
            Console.WriteLine(advertising);
            Console.WriteLine("Вас приветствует окно входа пользователя пользователя");
            Console.WriteLine("Введите свой логин и пароль в форму\n");
            Console.WriteLine("Login:\n");
            сursorPositionLogin = new СursorPosition(8, 9);
            Console.WriteLine("Password:\n");
            сursorPositionPassword = new СursorPosition(11, 11);
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("1 - Принять форму");
            Console.WriteLine("2 - Сбросить форму");
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
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
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("1 - Принять форму");
            Console.WriteLine("2 - Сбросить форму");
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("ESC - Вернуться в предыдущее меню");
        }
        static void PageNews(string advertising,string newsText, string newsTitle,int indexNews, int indexMaxNews)
        {
                string pageTitle = "Новости";
                string nextNews = "1 - Следующая новость";
                string prewNews = "2 - Предыдущая новость";
                Console.Clear();
                Console.SetWindowSize(80, 30);
                Console.SetBufferSize(80, 30);
                advertising = "*******************************************************************************\n*******************                                        ********************\n*********       А тут могла бы быть ваша реклама, но будет чужая     **********\n*********                 Казино Азино и всякая шляпа                **********\n*******************                                        ********************\n*******************************************************************************";
                newsText = "Многие любители японской кухни задаются вопросом, что такое нори. Используются \nнори для суши в классической японской кухне, при приготовлении роллов. Это спе-\nциальные водоросли, в которые заворачивают рыбу, рис и прочие ингредиенты. При \nэтом важно понимать, что нори представляют собой натуральный продукт, полностью\nбезопасный и очень полезный для организма человека. Как правило, такие водорос-\nли используются при приготовлении большинства суши и роллов любого вида. Но все\nингредиенты должны быть отменного качества, только в таком случае гарантиру-\nется уникальный вкус и свойства японского блюда\n";
                newsTitle = "НОРИ ДЛЯ СУШИ\n";
                Console.WriteLine(advertising);
                Console.WriteLine(pageTitle);
                Console.WriteLine(newsTitle);
                Console.WriteLine(newsText);
                Console.SetCursorPosition(0, 23);
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
                Console.SetCursorPosition(40, 23);
                Console.WriteLine("3 - Открыть ссылку в браузере");
                //Process.Start("E:\\LearnWeb\\start.html"); запись файла  и Запуск ссылки сделать
                Console.SetCursorPosition(40, 24);
                Console.WriteLine("ESC - Вернуться в предыдущее меню");

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
