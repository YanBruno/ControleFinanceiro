using ControleFinanceiro.Shared.Entities.Contracts;
using System;

namespace ControleFinanceiro.Domain.Entities.Inputs.Contracts
{
    public interface IInput: IEntity
    {
        public abstract string Type { get; }
        public double Value { get;  }
        public string Description { get; }
        public DateTime DueDate { get; }
        public DateTime InputDate { get; }
        public bool Done { get; }

        void MarkAsDone();
        void MarkAsUndone();
    }
}
