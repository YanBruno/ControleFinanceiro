using ControleFinanceiro.Shared.Entities.Contracts;
using System;

namespace ControleFinanceiro.Domain.Entities.Inputs.Contracts
{
    public abstract class Input : Entity, IInput
    {
        private readonly DateTime _inputDate = DateTime.Now;

        protected Input(double value, string description, DateTime dueDate, Guid id):base(id)
        {
            Value = value;
            Description = description;
            DueDate = dueDate;
            Done = false;
        }
        protected Input(double value, string description, DateTime dueDate) : base()
        {
            Value = value;
            Description = description;
            DueDate = dueDate;
            Done = false;
        }

        public abstract string Type { get ; protected set; }
        public double Value { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DueDate { get; protected set; }
        public DateTime InputDate => _inputDate;
        public bool Done { get; private set; }

        public void MarkAsDone() 
        {
            Done = true;
        }
        public void MarkAsUndone()
        {
            Done = false;
        }
    }
}