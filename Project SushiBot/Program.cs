using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string userLogin = string.Empty;
            //List<ProductData> userProductOrderData = new List<ProductData>();
            ProductOrderData productOrderData = new ProductOrderData();
            EnumPage enumPage = EnumPage.PageGreeting;
            start:
            switch (enumPage)
            {
                case EnumPage.PageGreeting:
                    {
                        PageProgram.PageGreeting(AdvertisingsBannerDataBase.RandomBanner());
                        startPageGreeting:
                        enumPage = PageProgram.PageGreetingBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Exit:
                                {
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
                        PageProgram.PageUserLogin(AdvertisingsBannerDataBase.RandomBanner(), out СursorPosition сursorPositionLogin, out СursorPosition сursorPositionPassword);
                        userLogin = PageInput.InputLogin(сursorPositionLogin);
                        PageInput.InputPassword(сursorPositionPassword, userLogin);
                        startPageLogin:
                        enumPage = PageProgram.PageUserLoginBottom();
                        switch (enumPage)
                        {
                            case EnumPage.Accept:
                                {
                                    enumPage = EnumPage.PageProfile;
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
                                    OpenFile.CreatePageBrowser(NewsDataRepository.GetNewsDataByIndex(ref IndexNews).Link);
                                    OpenFile.OpenPageBrowser();
                                    goto startPageNews;
                                }
                            case EnumPage.None:
                                {
                                    goto startPageNews;
                                }
                            default:
                                {
                                    OpenFile.DeletePageBrowser();
                                    break;
                                }
                        }
                        goto start;
                    }
                case EnumPage.PageStatusOrder:
                    {
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
                            case EnumPage.NextProduct:
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
                        int indexMenu = 0;
                        int indexProduct = 0;
                        List<ProductData> userProductOrderData = new List<ProductData>();
                        startPageOrderSushiIndexNew:
                        PageProgram.PageOrderSushi(AdvertisingsBannerDataBase.RandomBanner(), UserDataRepository.GetUserDataByLogin(userLogin), ProductInfoDataBase.MenuData, indexMenu, ProductInfoDataRepository.GetProductDataByindex(ref indexMenu, ref indexProduct), out СursorPosition сursorPositionInputAmount);
                        startPageOrderSushi:
                        enumPage = PageProgram.PageOrderSushiBottom();
                        switch (enumPage)
                        {
                            case EnumPage.NextProduct:
                                {
                                    indexProduct += 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.PrevProduct:
                                {
                                    indexProduct -= 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.UpProduct:
                                {
                                    indexMenu += 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.DownProduct:
                                {
                                    indexMenu -= 1;
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.Amount:
                                {
                                    int amount = PageInput.InputAmount(сursorPositionInputAmount);
                                    if (amount > 0)
                                    {
                                        userProductOrderData.Add(new ProductData(ProductInfoDataRepository.GetProductDataByindex(ref indexMenu, ref indexProduct), amount));
                                    }
                                    goto startPageOrderSushiIndexNew;
                                }
                            case EnumPage.PageRegistrationOrder:
                                {
                                    if (userProductOrderData == null)
                                    {
                                        enumPage = EnumPage.PageProfile;
                                        PageProgram.PageInfo(AdvertisingsBannerDataBase.RandomBanner(), "Вы ничего не выбрали");
                                    }
                                    else
                                    {
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
                                    productOrderData.SetInfoOrder(newOrderStreet, newOrderHouse, newOrderApartment, newOrderPhone);
                                    ProductOrderDataBaseRepository.CreateProductOrderUserData(productOrderData);
                                    ProductOrderDataBaseRepository.SaveAllProductOrderData();
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
            Console.Read();
        }
    }
}
