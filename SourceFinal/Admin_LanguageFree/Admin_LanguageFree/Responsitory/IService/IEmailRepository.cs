using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IService
{
    public interface IEmailRepository
    {
        Task SendMail(MailContent mailContent);
        Task SendEmailAsync(string email, string subject, string message);
    }
}
