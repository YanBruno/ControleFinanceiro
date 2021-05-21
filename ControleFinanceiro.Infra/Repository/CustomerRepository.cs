using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.Queries;
using ControleFinanceiro.Domain.Queries.Results;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Domain.ValueObjects;
using ControleFinanceiro.Infra.DataContexts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControleFinanceiro.Infra.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ControleFinanceiroContext _context;

        public CustomerRepository(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }
        public bool CheckPhone(string countryCode, string ddd, string phone)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckPhoneNumber",
                    new { countryCode, ddd, phone },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<CustomerQueryResult> GetAll()
        {
            return _context
                .Connection
                .Query<CustomerQueryResult>("spGetAllCustomer", new { }, commandType: CommandType.StoredProcedure);
        }

        public Customer GetByEmail(string email)
        {
            var resultCustomer = _context
                .Connection
                .Query<CustomerQueryResult>("Select * from tblCustomer where EmailAddress = @email", new { email }, commandType: CommandType.Text).FirstOrDefault();

            if (resultCustomer == null)
                return null;

            return new Customer(
                new Name(resultCustomer.FirstName, resultCustomer.LastName),
                new Email(resultCustomer.EmailAddress),
                new Phone(resultCustomer.PhoneNumber.Substring(2, 2), resultCustomer.PhoneNumber.Substring(4, 9)),
                new Statement(resultCustomer.Description, resultCustomer.StatementId),
                resultCustomer.Id
            );

        }

        public Customer GetById(Guid id)
        {
            var resultCustomer = _context
                .Connection
                .Query<CustomerQueryResult>("spGetCustomer" , new { Id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

            if (resultCustomer == null)
                return null;

            return new Customer(
                new Name(resultCustomer.FirstName, resultCustomer.LastName),
                new Email(resultCustomer.EmailAddress),
                new Phone(resultCustomer.PhoneNumber.Substring(2, 2), resultCustomer.PhoneNumber.Substring(4, 9)),
                new Statement(resultCustomer.Description, resultCustomer.StatementId),
                id
            );
        }
        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    customer.Id,
                    customer.Name.FirstName,
                    customer.Name.LastName,
                    Email = customer.Email.Address,
                    Phone = customer.Phone.ToString(),
                    StatementId = customer.Statement.Id,
                    customer.Statement.Description
                }, commandType: CommandType.StoredProcedure);

        }
    }
}