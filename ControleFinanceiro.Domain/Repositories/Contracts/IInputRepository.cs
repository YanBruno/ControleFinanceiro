using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.Queries.Results;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Domain.Repositories.Contracts
{
    public interface IInputRepository
    {
        void Save(Input input);
        void SaveFromStatement(Statement statement);
        IEnumerable<InputQueryResult> Get(Guid CustomerId);
    }
}
