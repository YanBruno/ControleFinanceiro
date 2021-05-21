using ControleFinanceiro.Domain.Queries.Contracts;
using ControleFinanceiro.Domain.Queries.Results;
using System;

namespace ControleFinanceiro.Domain.Queries
{
    public class CustomerQueries : Query<CustomerQueryResult>
    {
        public CustomerQueries QueryId(Guid id)
        {
            _filters.Add(x => x.Id == id);
            return this;
        }
        public CustomerQueries QueryStatementId(Guid id)
        {
            _filters.Add(x => x.StatementId == id);
            return this;
        }
    }
}
