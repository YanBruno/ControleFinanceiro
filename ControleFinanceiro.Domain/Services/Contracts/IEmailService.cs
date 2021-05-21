using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.Services.Contracts
{
    public interface IEmailService
    {
        void Send(Email email, string subject, string body);
    }
}
