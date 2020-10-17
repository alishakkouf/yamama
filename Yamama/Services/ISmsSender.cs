using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Services
{
  public  interface ISmsSender
    {
        Task<Twilio.Rest.Api.V2010.Account.MessageResource> SendSmsAsync(string number, string message);
    }
}