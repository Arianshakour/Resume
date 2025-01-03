using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Bus.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<bool> SendEmail(string to, string subject, string body);
    }
}
