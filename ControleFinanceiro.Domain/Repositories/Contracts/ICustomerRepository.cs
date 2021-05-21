using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Queries.Results;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Domain.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        Customer GetByEmail(string email);
        IEnumerable<CustomerQueryResult> GetAll();
        void Save(Customer customer);
        bool CheckEmail(string email);
        bool CheckPhone(string countryCode, string ddd, string phone);
    }
}
