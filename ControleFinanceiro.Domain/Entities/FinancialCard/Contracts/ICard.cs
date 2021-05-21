using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using ControleFinanceiro.Domain.ValueObjects;
using System;

namespace ControleFinanceiro.Domain.Entities.CreditCard.Contracts
{
    public interface ICard
    {
        public abstract string Type { get; }
        public string CardNumber { get; }
        public Name Name { get; }
        public string CVV { get; }
        public DateTime Valid { get; }

        public void AddInput(IInput input);
    }
}
