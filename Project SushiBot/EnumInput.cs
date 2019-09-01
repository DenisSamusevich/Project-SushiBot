using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    //enum EnumInput
    //{
    //    None = 0,
    //    LogIn = 1,
    //    Back = 2,
    //    Reset = 3,
    //    OpenBrowser = 4,
    //    Following = 5,
    //    Previous = 6,
    //    Exit = 7,
    //    SignUp = 8,
    //    News = 9,
    //    OpenOrder = 10,
    //    OpenStatus = 11,
    //    Refresh =12,
    //    UpProduct = 13,
    //    DownProduct = 14,
    //    InputAmount = 15,
    //    RegistrationOrder =16,
    //}
    enum EnumPage // Значение 3
    {
        None = 0,
        PageGreeting = 1,
        PageLogin = 2,
        PageNews = 4,
        PageRegisterNewUser = 5,
        PageProfile = 6,
        PageStatusOrder = 7,
        PageOrderSushi = 8,
        PageRegistrationOrder = 9,
        PageOrderEnd = 10,
        Amount = 11,
        Reset = 12,
        Accept = 13,
        NextNews = 14,
        PrevNews = 15,
        OpenBrowser = 16,
        NextOrder = 17,
        PrevOrder = 18,
        UpProduct = 19,
        DownProduct = 20,
        NextProduct = 21,
        PrevProduct = 22,
        Exit =23,
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
