using ControleFinanceiro.Domain.Commands.Input.Contracts;
using System;

namespace ControleFinanceiro.Domain.Commands.Input
{
    public class CreateDebitCommand : CreateInputCommand
    {
        public CreateDebitCommand()
        {
        }

        public CreateDebitCommand(Guid customerId, double value, string description, DateTime dueDate) : base(customerId, value, description, dueDate)
        {

        }
    }
}
