using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetEmptyProj.Services
{
    public class EmailSender : IMessageSender
    {
        public string Send()
        {
            return "Sent by Email";
        }
    }
}
