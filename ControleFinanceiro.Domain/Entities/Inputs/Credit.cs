using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using System;

namespace ControleFinanceiro.Domain.Entities.Inputs
{
    public class Credit : Input
    {
        public Credit(double value, string description, DateTime dueDate) : base(value, description, dueDate)
        {
        }
        public Credit(double value, string description, DateTime dueDate, Guid id) : base(value, description, dueDate, id)
        {
        }

        public override string Type { get { return GetType().Name; } protected set => _ = GetType().Name; }
    }
}