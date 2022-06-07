using HospitalManagement.BL.Contracts;
using HospitalManagement.BL.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HospitalManagement.BL
{
    public class SmsService : ISmsService
    {
        private readonly TwilioApi _twilioApi;



        public SmsService(IOptions<TwilioApi> twilioApi)
        {
            _twilioApi = twilioApi.Value;
        }
        public string SendSms(SMS message)
        {
            TwilioClient.Init(_twilioApi.AuthSID, _twilioApi.AuthToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber(message.To))
            {
                From = new PhoneNumber(_twilioApi.TwilioPhoneNumber),
                MessagingServiceSid = _twilioApi.MessagingServiceSid,
                Body = message.Body
            };

            var messageToSend = MessageResource.Create(messageOptions);

            return $"{messageToSend.Status} {messageToSend.Sid}";
        }
    }
}
