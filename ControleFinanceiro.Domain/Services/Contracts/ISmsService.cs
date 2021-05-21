using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.Services.Contracts
{
    public interface ISmsService
    {
        void Send(Phone to, string message);
    }
}
