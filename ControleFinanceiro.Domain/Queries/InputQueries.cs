using ControleFinanceiro.Domain.Queries.Contracts;
using ControleFinanceiro.Domain.Queries.Results;
using System;

namespace ControleFinanceiro.Domain.Queries
{
    public class InputQueries : Query<InputQueryResult>
    {
        public InputQueries QueryId(Guid id) 
        {
            _filters.Add(x=> x.Id == id);
            return this;
        }
        public InputQueries QueryDone(bool done)
        {
            _filters.Add(x => x.Done == done);
            return this;
        }
        public InputQueries QueryDescription(string description)
        {
            _filters.Add(x => x.Description == description);
            return this;
        }
        public InputQueries QueryType(string type)
        {
            _filters.Add(x => x.Type == type);
            return this;
        }

    }
}