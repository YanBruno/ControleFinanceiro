using ControleFinanceiro.Domain.Queries.Contracts;
using ControleFinanceiro.Domain.Queries.Results;
using System;

namespace ControleFinanceiro.Domain.Queries
{
    public class StatementQueries : Query<StatementQueryResult>
    {
        public StatementQueries QueryCustomerId(Guid id)
        {
            _filters.Add(x=> x.CustomerId == id);
            return this;
        }

    }
}