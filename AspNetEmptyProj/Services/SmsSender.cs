using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetEmptyProj.Services
{
    public class SmsSender : IMessageSender
    {
        public string Send()
        {
            return "Sent by Sms";
        }
    }
}
