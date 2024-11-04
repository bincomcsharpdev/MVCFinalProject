﻿using FinalAssProject.Interfaces;
using FinalAssProject.Models;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace FinalAssProject.Repositories
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmail(EmailDto request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Facts Resume", _emailSettings.SenderEmail));
            message.To.Add(new MailboxAddress("", request.ToEmail));
            message.Subject = request.Subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Body
            };

            var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }



        }
    }
}
