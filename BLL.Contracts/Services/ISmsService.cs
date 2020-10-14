namespace BLL.Contracts.Services
{
    public interface ISmsService
    {
        void SendSms(string phoneNumber, string message);
    }
}