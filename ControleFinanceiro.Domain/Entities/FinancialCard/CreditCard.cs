using ControleFinanceiro.Domain.Entities.CreditCard.Contracts;
using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using ControleFinanceiro.Domain.ValueObjects;
using System;

namespace ControleFinanceiro.Domain.Entities.FinancialCard
{
    public class CreditCard : ICard
    {
        public string Type => throw new NotImplementedException();

        public string CardNumber => throw new NotImplementedException();

        public Name Name => throw new NotImplementedException();

        public string CVV => throw new NotImplementedException();

        public DateTime Valid => throw new NotImplementedException();

        public void AddInput(IInput input)
        {
        }
    }
}
