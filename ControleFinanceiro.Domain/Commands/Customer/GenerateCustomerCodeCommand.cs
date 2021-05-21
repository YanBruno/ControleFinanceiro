using ControleFinanceiro.Domain.Commands.Contracts;

namespace ControleFinanceiro.Domain.Commands.Customer
{
    public class GenerateCustomerCodeCommand : ICommand
    {
        public string Email { get; set; }

        public void Validate()
        {
            
        }
    }
}
