﻿namespace AspNetLesson.Services.Impl
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send()
        {
            return "Sent by SMS";
        }
    }
}
