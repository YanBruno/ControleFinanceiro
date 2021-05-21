using System;

namespace ControleFinanceiro.Domain.Queries.Results
{
    public class StatementQueryResult
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
    }
}
