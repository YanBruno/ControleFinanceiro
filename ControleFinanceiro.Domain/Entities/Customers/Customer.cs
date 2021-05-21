
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.ValueObjects;
using ControleFinanceiro.Shared.Entities.Contracts;
using System;

namespace ControleFinanceiro.Domain.Entities.Customer
{
    public class Customer : Entity
    {
        public Customer(Name name, Email email, Phone phone, Statement statement):base()
        {
            Name = name;
            Email = email;
            Phone = phone;
            Statement = statement;
        }
        public Customer(Name name, Email email, Phone phone, Statement statement, Guid id):base(id)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Statement = statement;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Statement Statement { get; private set; }
    }
}
