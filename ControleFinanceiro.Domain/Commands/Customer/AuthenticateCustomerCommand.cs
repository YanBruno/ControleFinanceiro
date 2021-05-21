using ControleFinanceiro.Domain.Commands.Contracts;

namespace ControleFinanceiro.Domain.Commands.Customer
{
    public class AuthenticateCustomerCommand : ICommand
    {
        public string Code { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            
        }
    }
}
