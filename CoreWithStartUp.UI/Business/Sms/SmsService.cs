using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWithStartUp.UI.Business
{
    public class SmsService : ISmsService
    {
        public void Send(Sms mail)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Header    : {mail.Header}");
            sb.AppendLine($"Content   : {mail.Content}");
            sb.AppendLine($"SendingDate    : {mail.SendingDate}");
            Console.WriteLine(sb.ToString());
        }
    }

}
