﻿using MailKit.Net.Smtp;
using MimeKit;
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using QueenFisher.Core.Interfaces.IServices;

namespace QueenFisher.Core.Services
{
    public class EmailService : IEmailService
    { 

        private readonly EmailConfiguration _emailConfig;
    
        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("QueenFisher", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = string.Format("<p>{0}</p>", message.Content) };
            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception or both.
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
