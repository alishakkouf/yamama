using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Models;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.AspNetCore.Builder;

namespace Yamama.Services
{
    public class AuthMessageSender :  ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSMSSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSender()
        {

        }

        public AuthMessageSMSSenderOptions Options { get; }  // set only via Secret Manager

   

        public Task<Twilio.Rest.Api.V2010.Account.MessageResource> SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = Options.SID;
            // Your Auth Token from twilio.com/console
            var authToken = Options.AuthToken;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
              to: new PhoneNumber(number),
              from: new PhoneNumber(Options.SMSAccountFrom),
              body: message);
        }
    }
}