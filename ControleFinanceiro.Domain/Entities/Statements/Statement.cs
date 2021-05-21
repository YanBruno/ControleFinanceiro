using ControleFinanceiro.Domain.Entities.CreditCard.Contracts;
using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using ControleFinanceiro.Domain.Entities.Statements.Contracts;
using ControleFinanceiro.Shared.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFinanceiro.Domain.Entities.Statements
{
    public class Statement : Entity, IStatement
    {
        private readonly IList<IInput> _inputs = new List<IInput>();
        private readonly IList<ICard> _cards = new List<ICard>();

        public Statement(string description):base()
        {
            Description = description;
        }
        public Statement(string description, Guid id) : base(id)
        {
            Description = description;
        }

        //Todo: Mais de um Statement por Customer

        public IReadOnlyCollection<ICard> Cards => _cards.ToArray();
        public IReadOnlyCollection<IInput> Inputs => _inputs.ToArray();

        public string Description { get; private set; }

        public void AddInput(IInput input)
        {
            _inputs.Add(input);
        }
        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }
    }
}