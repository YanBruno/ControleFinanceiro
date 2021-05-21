using ControleFinanceiro.Domain.Entities.CreditCard.Contracts;
using ControleFinanceiro.Domain.Entities.Inputs.Contracts;

namespace ControleFinanceiro.Domain.Entities.Statements.Contracts
{
    public interface IStatement
    {
        string Description { get; }

        void AddInput(IInput input);
        void AddCard(ICard card);
    }
}
