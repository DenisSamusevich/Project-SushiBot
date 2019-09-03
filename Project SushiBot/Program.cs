using System;
using System.Collections.Generic;
using System.Threading;


namespace Project_SushiBot
{
    class Program
    {
        private static readonly Logger logger = new Logger();
        static void Main(string[] args)
        {
            string userLogin = string.Empty;
            ProductOrderData productOrderData = new ProductOrderData();
            EnumPage enumPage = EnumPage.PageGreeting;
            logger.Info("Start program", Thread.CurrentThread);
            start:
            switch (enumPage)
            {
                case EnumPage.PageGreeting:
                    {
                        logger.Info("Page greeting", Thread.CurrentThread);
                        PageProgram.PageGreeting(AdvertisingsBannerDataBase.RandomBanner());
                        startPageGreeting:
                        enumPage = PageProgram.PageGreetingBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Exit:
                                {
                                    logger.Info("Exit program", Thread.CurrentThread);
                                    Environment.Exit(0);
                                    break;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageGreeting;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageLogin:
                    {
                        logger.Info("Page user login", Thread.CurrentThread);
                        PageProgram.PageUserLogin(AdvertisingsBannerDataBase.RandomBanner(), out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword);
                        userLogin = PageInput.InputLogin(сursorPositionLogin);
                        PageInput.InputPassword(сursorPositionPassword, userLogin);
                        startPageLogin:
                        enumPage = PageProgram.PageUserLoginBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Accept:
                                {
                                    logger.Info("User login", Thread.CurrentThread);
                                    enumPage = EnumPage.PageProfile;
                                    PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Вы успешно вошли в систему");
                                    break;
                                }
                            case EnumPage.Reset:
                                {
                                    enumPage = EnumPage.PageLogin;
                                    break;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageLogin;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageRegisterNewUser:
                    {
                        logger.Info("Page user register", Thread.CurrentThread);
                        PageProgram.PageRegisterNewUser(AdvertisingsBannerDataBase.RandomBanner(), out СursorPosition сursorPositionRegisterSurname, out СursorPosition сursorPositionRegisterName, out СursorPosition сursorPositionRegisterEmail, out СursorPosition сursorPositionRegisterLogin, out СursorPosition сursorPositionRegisterPassword, out СursorPosition сursorPositionRegisterRepeatPassword);
                        string newUserSurname = PageInput.InputRegistrationSurname(сursorPositionRegisterSurname);
                        string newUserName = PageInput.InputRegistrationName(сursorPositionRegisterName);
                        string newUserEmail = PageInput.InputRegistrationEmail(сursorPositionRegisterEmail);
                        string newUserLogin = PageInput.InputRegistrationLogin(сursorPositionRegisterLogin);
                        string newUserPassword = PageInput.InputRegistrationPassword(сursorPositionRegisterPassword, сursorPositionRegisterRepeatPassword);
                        startPageRegister:
                        enumPage = PageProgram.PageUserLoginBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Accept:
                                {
                                    logger.Info("User register", Thread.CurrentThread);
                                    enumPage = EnumPage.PageGreeting;
                                    UserDataRepository.CreateUserData(new UserData(newUserEmail, newUserName, newUserSurname, newUserLogin, newUserPassword));
                                    PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Вы успешно зарегестрировались");
                                    break;
                                }
                            case EnumPage.Reset:
                                {
                                    enumPage = EnumPage.PageRegisterNewUser;
                                    break;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageRegister;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageProfile:
                    {
                        logger.Info("Page profile", Thread.CurrentThread);
                        PageProgram.PageProfile(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin));
                        startPageProfile:
                        enumPage = PageProgram.PageProfileBottom();
                        switch (enumPage)
                        {
                            case EnumPage.None:
                                {
                                    goto startPageProfile;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageNews:
                    {
                        logger.Info("Page news", Thread.CurrentThread);
                        int IndexNews = 0;
                        startPageNewsIndexNew:
                        PageProgram.PageNews(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), NewsDataRepository.GetNewsDataByIndex(ref IndexNews));
                        startPageNews:
                        enumPage = PageProgram.PageNewsBottom();
                        switch (enumPage)
                        {
                            case EnumPage.PrevNews:
                                {
                                    IndexNews += 1;
                                    goto startPageNewsIndexNew;
                                }
                            case EnumPage.NextNews:
                                {
                                    IndexNews -= 1;
                                    goto startPageNewsIndexNew;
                                }
                            case EnumPage.OpenBrowser:
                                {
                                    NewsDataRepository.GetNewsDataByIndex(ref IndexNews).OpenPageBrowser();
                                    goto startPageNews;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageNews;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageStatusOrder:
                    {
                        logger.Info("Page status order", Thread.CurrentThread);
                        int IndexOrder = int.MaxValue;
                        startPageStatusOrderIndexNew:
                        PageProgram.PageStatusOrder(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), ProductOrderDataBaseRepository.ProductOrderUserDataByIndex(ref IndexOrder, userLogin));
                        startPageStatusOrder:
                        enumPage = PageProgram.PageStatusOrderBottom();
                        switch (enumPage)
                        {
                            case EnumPage.PrevOrder:
                                {
                                    IndexOrder += 1;
                                    goto startPageStatusOrderIndexNew;
                                }
                            case EnumPage.NextOrder:
                                {
                                    IndexOrder -= 1;
                                    goto startPageStatusOrderIndexNew;
                                }
                            case EnumPage.Reset:
                                {
                                    goto startPageStatusOrderIndexNew;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageStatusOrder;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageOrderSushi:
                    {
                        logger.Info("Page order sushi", Thread.CurrentThread);
                        int indexMenu = 0;
                        int indexProduct = 0;
                        List<ProductData> userProductOrderData = new List<ProductData>();
                        startPageOrderSushiIndexNew:
                        PageProgram.PageOrderSushi(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), ProductInfoDataBase.GetAllMenuData(), ref indexMenu, ProductInfoDataRepository.GetProductDataByindex(ref indexMenu, ref indexProduct), out СursorPosition сursorPositionInputAmount); ;
                        startPageOrderSushi:
                        enumPage = PageProgram.PageOrderSushiBottom();
                        switch (enumPage)
                        {
                            case EnumPage.NextProduct:
                                {
                                    indexMenu += 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.PrevProduct:
                                {
                                    indexMenu -= 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.UpProduct:
                                {
                                    indexProduct += 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.DownProduct:
                                {
                                    indexProduct -= 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.Amount:
                                {
                                    int amount = PageInput.InputAmount(сursorPositionInputAmount);
                                    if (amount > 0)
                                    {
                                        userProductOrderData.Add(new ProductData(ProductInfoDataRepository.GetProductDataByindex(ref indexMenu, ref indexProduct), amount));
                                    }
                                    goto startPageOrderSushi;
                                }
                            case EnumPage.PageRegistrationOrder:
                                {
                                    if (userProductOrderData.Count==0)
                                    {
                                        enumPage = EnumPage.PageProfile;
                                        PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Вы ничего не выбрали");
                                    }
                                    else
                                    {
                                        logger.Info("Order selected", Thread.CurrentThread);
                                        productOrderData = new ProductOrderData(userLogin, userProductOrderData);
                                        PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Заказ сформирован");
                                    }
                                    goto start;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageOrderSushi;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageRegistrationOrder:
                    {
                        logger.Info("Page registration order", Thread.CurrentThread);
                        PageProgram.PageRegistrationOrder(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), productOrderData);
                        startPageRegistrationOrder:
                        enumPage = PageProgram.PageRegistrationOrderBottom();
                        switch (enumPage)
                        {
                            case EnumPage.None:
                                { 
                                    goto startPageRegistrationOrder;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageOrderEnd:
                    {
                        logger.Info("Page order end", Thread.CurrentThread);
                        PageProgram.PageOrderEnd(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), out СursorPosition сursorPositionInputStreet, out СursorPosition сursorPositionInputHouse, out СursorPosition сursorPositionInputApartment, out СursorPosition сursorPositionInputPhone);
                        string newOrderStreet = PageInput.InputStreet(сursorPositionInputStreet);
                        string newOrderHouse = PageInput.InputHouse(сursorPositionInputHouse);
                        string newOrderApartment = PageInput.InputApartment(сursorPositionInputApartment);
                        string newOrderPhone = PageInput.InputPhone(сursorPositionInputPhone);
                        startPageOrderEnd:
                        enumPage = PageProgram.PageOrderEndBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Accept:
                                {
                                    logger.Info("Opder set data base", Thread.CurrentThread);
                                    productOrderData.SetInfoOrder(newOrderStreet, newOrderHouse, newOrderApartment, newOrderPhone);
                                    ProductOrderDataBaseRepository.CreateProductOrderUserData(productOrderData);
                                    ProductOrderDataBaseRepository.SaveAllProductOrderData();
                                    PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Заказ внесен в базу");
                                    ChangeStatusOrder.StartChangeOrder(productOrderData);
                                    enumPage = EnumPage.PageProfile;
                                    break;
                                }

                            case EnumPage.Reset:
                                {
                                    enumPage = EnumPage.PageOrderEnd;
                                    break;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageOrderEnd;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        goto start;
                    }
            }
            Console.WriteLine("получился выход");
            Console.Read();
        }
    }
}
