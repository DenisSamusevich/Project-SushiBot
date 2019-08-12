using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    enum EnumInput
    {
        None = 0,
        Enter = 1,
        Back = 2,
        Reset = 3,
        OpenBrowser = 4,
        Following = 5,
        Previous = 6,
        Exit = 7,
        SignUp = 8,
        News = 9,
        OpenOrder = 10,
        OpenStatus = 11,
        Refresh =12,
        UpProduct = 13,
        DownProduct = 14,
        InputAmount = 15,
        RegistrationOrder =16,
    }
    enum EnumPage
    {
        Greeting = 0,
        SingUp = 1,
        RegisterNewUser = 2,
        News = 3,
    }
    enum EnumStatusOrder
    {
        WaitingForPayment,
        OrderProcessing,
        OrderMaking,
        OrderDelivery,
        OrderСompleted,
        OrderСancelled,
    }
    //enum Menu
    //{
    //    Sets = 0,
    //    Maki = 1,
    //    Uramaki = 2,
    //    Futomaki = 3,
    //    Dessert = 4,
    //    Nigiri = 5,
    //    Gunkans = 6,
    //    Soups = 7,
    //    Drinks = 8,
    //}
}
