using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleFinanceiro.Domain.Queries.Contracts
{
    public abstract class Query<T>
    {
        protected readonly IList<Predicate<T>> _filters;
        public Query()
        {
            _filters = new List<Predicate<T>>();
        }
        public Expression<Func<T, bool>> Apply()
        {

            return IQueryResult => _filters.All(pred => pred(IQueryResult));
        }
    }
}