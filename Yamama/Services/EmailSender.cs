using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yamama.Repository;
using Yamama.ViewModels;

namespace Yamama.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task<int> SendEmailAsync(string from_email, string password , string to_email, string subject, string message, string attachement)
        {
            try
               {
                MimeMessage _message = new MimeMessage();
                //sender
                MailboxAddress from = new MailboxAddress("sender", from_email);
                             
                _message.From.Add(from);

                //reciever
                //for (int i = 0; i <= to_email.Length; i++)
                //{
                    MailboxAddress to = new MailboxAddress("reciever", to_email);
                    _message.To.Add(to);
                //}

                //subject
                _message.Subject = subject;

                BodyBuilder bodyBuilder = new BodyBuilder();

                //bodyBuilder.HtmlBody = "<h1></h1>";
                 bodyBuilder.TextBody = message;
                //bodyBuilder.Attachments.Add(attachement);
                _message.Body = bodyBuilder.ToMessageBody();

                SmtpClient client = new SmtpClient();
        
                client.Connect("smtp.yamama.prokoders.work",465, true);

                client.Authenticate(from_email, password);

                await client.SendAsync(_message);

                await client.DisconnectAsync(true);

                return 1;



            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}

