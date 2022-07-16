using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWithStartUp.UI.Business
{
    public class MailService : IMailService
    {
        public bool Send(Mail mail)
        {
            var IsSuccess = true;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Header    : {mail.Header}");
                sb.AppendLine($"Content   : {mail.Content}");
                sb.AppendLine($"SendingDate    : {mail.SendingDate}");
                Console.WriteLine(sb.ToString());
            }
            catch (Exception)
            {
                IsSuccess = false;
                throw;
            }

            return IsSuccess;
        }
    }

}
