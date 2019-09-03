using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class MailSender
    {
        private static readonly Logger logger = new Logger();
        MailAddress MailAddressFrom { get; } = new MailAddress("developtestprogramemail@gmail.com");
        MailAddress MailAddressTo { get; }
        MailMessage MailMessageFromTo { get; }
        SmtpClient SmtpClient { get; } 

        internal MailSender(string mailAddressTo)
        {
            MailAddressTo = new MailAddress(mailAddressTo);
            MailMessageFromTo = new MailMessage(MailAddressFrom, MailAddressTo);
            SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            SmtpClient.Credentials = new NetworkCredential("developtestprogramemail@gmail.com", "developtest");
            SmtpClient.EnableSsl = true;
        }
        internal void MailSendOrderMaking(ProductOrderData productOrderData)
        {
            logger.Info("Send message making", Thread.CurrentThread);
            MailMessageFromTo.Subject = "Заказ оформлен";
            MailMessageFromTo.Body = string.Format("Спасибо!\nЗдравствуйте! Благодорим вас за заказ №{0}.\nВ настоящее время ваш заказ находится на стадии комплектования продуктов, это может занять некоторое время. Мы обязательно сообщим вам когда наш курьер отправится к вам", productOrderData.GetNumberOrder());
            MailMessageFromTo.IsBodyHtml = false;
            SmtpClient.Send(MailMessageFromTo);
        }
        internal void MailSendOrderDelivery(ProductOrderData productOrderData)
        {
            logger.Info("Send message delivery", Thread.CurrentThread);
            MailMessageFromTo.Subject = "Заказ скомплектован";
            MailMessageFromTo.Body = string.Format("Здравствуйте! Ваш заказ готов.\nВ ближайшее время курьер доставит на ваш адрес.", productOrderData.GetNumberOrder());
            SmtpClient.Send(MailMessageFromTo);
        }
        internal void MailSendOrderСompleted(ProductOrderData productOrderData)
        {
            logger.Info("Send message completed", Thread.CurrentThread);
            MailMessageFromTo.Subject = "Заказ доставлен";
            MailMessageFromTo.Body = string.Format("Здравствуйте! Ваш заказ доставлен.\nСпасибо за то что пользуетесь нашими услугами.", productOrderData.GetNumberOrder());
            SmtpClient.Send(MailMessageFromTo);
        }
    }
}
