using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    static class ChangeStatusOrder
    {
        internal static void StartChangeOrder(ProductOrderData productOrderData)
        {
            Thread threadChangeOrder = new Thread(()=> ChangeAndSaveOrder(productOrderData));
            threadChangeOrder.Start();
        }
        internal static void ChangeAndSaveOrder(ProductOrderData productOrderData)
        {
            MailSender mailSender = new MailSender(UserDataRepository.GetUserDataByLogin(productOrderData.GetLoginOrder()).Email);
            mailSender.MailSendOrderMaking(productOrderData);
            Thread.Sleep(TimeSpan.FromMinutes(1));
            ProductOrderDataBaseRepository.UpdateStatusOrderData(productOrderData);
            ProductOrderDataBaseRepository.SaveAllProductOrderData();
            mailSender.MailSendOrderDelivery(productOrderData);
            Thread.Sleep(TimeSpan.FromMinutes(1));
            ProductOrderDataBaseRepository.UpdateStatusOrderData(productOrderData);
            ProductOrderDataBaseRepository.SaveAllProductOrderData();
            mailSender.MailSendOrderСompleted(productOrderData);
        }
    }
}
