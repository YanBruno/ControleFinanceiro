using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Statements;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Domain.Repositories.Contracts
{
    public interface IStatementRepository
    {
        void Save(Statement statement);
        IEnumerable<Statement> GetStatements(Customer customer);
        Statement GetStatement(Guid id);
    }
}