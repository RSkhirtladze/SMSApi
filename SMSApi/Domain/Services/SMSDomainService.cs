using SMSApi.Domain.Interfaces;
using SMSApi.Domain.Models;

namespace SMSApi.Domain.Services
{
    public class SMSDomainService : ISMSDomainService
    {
        public void ProcessMessage(SMSMessage message)
        {
            ///
            ///...
            ///
            //Probably check if message content contains prohibited words (?)
            //or is formated specifically for business requirements
            //Basically any business-specific-logic that must be enforced before sending message should be here
            //(check if its okay to send message at 2a.m for example or if we have reached our message limit)
            ///
            ///...
            ///
        }
    }
}
