using CoreWithStartUp.UI.Log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWithStartUp.UI.Business
{
    public class CardManager : ICardManager
    {
        private readonly IConsoleLogger _consoleLogger;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        //DI with Constructor
        public CardManager(IConsoleLogger consoleLogger, IMailService mailService,IConfiguration configuration)
        {
            _consoleLogger = consoleLogger;
            _mailService = mailService;
            _configuration = configuration;
        }

        public void ShoppingCard(Shopping shopping)
        {

            var passWordKey = _configuration.GetSection("MailPasswordKey")?.Value;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ProductName     : {shopping.ProductName}");
            sb.AppendLine($"Price           : {shopping.Price}");
            sb.AppendLine($"ShoopingDate    : {shopping.ShoopingDate}");

            var result = _mailService.Send(new Mail { Header = "Product Selling", Content = sb.ToString(), Sender = "1", Receiver = "2" , MailPasswordKey= passWordKey });
            if (result)
                _consoleLogger.Success("Ürün Satışı yapıldı ve Mail Gönderme başarılı oldu");
            else
                _consoleLogger.Error("Ürün Satışı başarısız");

        }
    }
}
