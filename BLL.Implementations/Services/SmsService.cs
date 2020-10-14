using System;
using BLL.Contracts.Services;

namespace BLL.Implementations.Services
{
    public class SmsService : ISmsService
    {
        public void SendSms(string phoneNumber, string message)
        {
            // Использование провайдера для отправки смс.
            throw new NotImplementedException();
        }
    }
}
