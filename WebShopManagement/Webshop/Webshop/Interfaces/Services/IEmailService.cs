namespace Webshop.Interfaces.Services
{
    public interface IEmailService
    {
        void Send(string to, string subject, string body);
    }
}