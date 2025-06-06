﻿using BusinessObject.Model;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit;
using Reponsitory.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.IService;

namespace Repository.Service
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;
        private readonly EmailSetting mailSettings;
        private readonly ILogger<EmailRepository> logger;

        public EmailRepository(IOptions<EmailSetting> _mailSettings, ILogger<EmailRepository> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation("Create SendMailService");
        }

        public async Task SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await email.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }
            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + mailContent.To);

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }
    }

}