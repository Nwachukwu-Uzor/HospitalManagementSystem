using HospitalManagement.BL.Contracts;
using HospitalManagement.BL.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HospitalManagement.BL
{
    public class SmsService : ISmsService
    {
        private readonly TwilioApi _twilioApi;
        private readonly TwilioRestClient _client;



        public SmsService(IOptions<TwilioApi> twilioApi)
        {
            _twilioApi = twilioApi.Value;
            _client = new TwilioRestClient(_twilioApi.AuthSID, _twilioApi.AuthToken);
        }
        public void SendSms(SMS message)
        {
            TwilioClient.Init(_twilioApi.AuthSID, _twilioApi.AuthToken);
            var messageSent = MessageResource.Create(
                new PhoneNumber(message.To),
                _twilioApi.TwilioPhoneNumber,
                message.Body
            );
        }
    }
}
