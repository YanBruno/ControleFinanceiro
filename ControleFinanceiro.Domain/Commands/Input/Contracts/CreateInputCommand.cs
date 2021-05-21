using ControleFinanceiro.Domain.Commands.Contracts;
using System;

namespace ControleFinanceiro.Domain.Commands.Input.Contracts
{
    public abstract class CreateInputCommand : ICommand
    {
        protected CreateInputCommand()
        {
        }

        protected CreateInputCommand(Guid customerId, double value, string description, DateTime dueDate)
        {
            CustomerId = customerId;
            Value = value;
            Description = description;
            DueDate = dueDate;
        }

        public Guid CustomerId { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public void Validate()
        {
            
        }
    }
}
