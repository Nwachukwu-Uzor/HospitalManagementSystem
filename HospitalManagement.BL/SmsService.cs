using HospitalManagement.BL.Contracts;
using HospitalManagement.BL.Models;
using System;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HospitalManagement.BL
{
    public class SmsService : ISmsService
    {
        private readonly TwilioRestClient _client;
        private readonly string _authSID;
        private readonly string _authToken;
        private readonly string _twillioNumber;


        public SmsService()
        {
            _authSID = Environment.GetEnvironmentVariable("TWILLIO_AUTH_SID");
            _authToken = Environment.GetEnvironmentVariable("TWILLIO_AUTH_TOKEN");
            _twillioNumber = Environment.GetEnvironmentVariable("TWILLIO_NUMBER");
            _client = new TwilioRestClient(_authSID, _authToken);
            
        }
        public void SendSms(SMS message)
        {
            TwilioClient.Init(_authSID, _authToken);
            var messageSent = MessageResource.Create(
                new PhoneNumber(message.To),
                _twillioNumber,
                message.Body
            );
        }
    }
}
