using ControleFinanceiro.Domain.Services.Contracts;
using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.ConsoleTestes
{
    public class EmailService : IEmailService
    {
        public void Send(Email email, string subject, string body)
        {
        }
    }
}
