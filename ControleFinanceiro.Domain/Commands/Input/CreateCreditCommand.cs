using ControleFinanceiro.Domain.Commands.Input.Contracts;
using System;

namespace ControleFinanceiro.Domain.Commands.Input
{
    public class CreateCreditCommand : CreateInputCommand
    {
        public CreateCreditCommand()
        {
        }

        public CreateCreditCommand(Guid customerId, double value, string description, DateTime dueDate) : base(customerId, value, description, dueDate)
        {
        }
    }
}
