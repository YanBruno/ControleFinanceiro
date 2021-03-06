using System;

namespace ControleFinanceiro.Shared.Entities.Contracts
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
