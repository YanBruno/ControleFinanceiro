using ControleFinanceiro.Domain.Entities.Customer;

namespace ControleFinanceiro.Domain.Services.Contracts
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
