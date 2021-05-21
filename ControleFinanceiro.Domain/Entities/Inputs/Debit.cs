using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using System;

namespace ControleFinanceiro.Domain.Entities.Inputs
{
    public class Debit : Input
    {
        public Debit(double value, string description, DateTime dueDate) : base(value, description, dueDate)
        {
        }

        public Debit(double value, string description, DateTime dueDate, Guid id) : base(value, description, dueDate, id)
        {
        }

        public override string Type { get { return GetType().Name; } protected set => _ = GetType().Name; }
    }
}