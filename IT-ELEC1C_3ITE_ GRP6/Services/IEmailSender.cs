using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_ELEC1C_3ITE__GRP6.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
