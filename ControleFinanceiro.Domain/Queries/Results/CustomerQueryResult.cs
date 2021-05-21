using System;

namespace ControleFinanceiro.Domain.Queries.Results
{
    public class CustomerQueryResult
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Guid StatementId { get; set; }
        public string Description { get; set; }
    }
}
