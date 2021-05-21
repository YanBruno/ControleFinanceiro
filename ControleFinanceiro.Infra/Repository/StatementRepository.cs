using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.Queries;
using ControleFinanceiro.Domain.Queries.Results;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Infra.DataContexts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ControleFinanceiro.Infra.Repository
{
    public class StatementRepository : IStatementRepository
    {
        private readonly ControleFinanceiroContext _context;

        public StatementRepository(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public Statement GetStatement(Guid id)
        {
            var statementResult = _context.Connection.Query<StatementQueryResult>("Select * from tblStatement where StatementId = @Id", new { id }, commandType: CommandType.Text).FirstOrDefault();
            return new Statement(statementResult.Description, statementResult.Id);

        }

        public IEnumerable<Statement> GetStatements(Customer customer)
        {
            var statementResult =
                _context.Connection
                .Query<StatementQueryResult>("Select * from tblStatement", new { }, commandType: CommandType.Text)
                .AsQueryable()
                .Where(
                    new StatementQueries()
                        .QueryCustomerId(customer.Id)
                        .Apply()
                );

            var statements = new List<Statement>();

            foreach (var item in statementResult)
            {
                var statement = new Statement(
                    item.Description,
                    item.Id
                    );

                statements.Add(statement);
            }

            return statements;
        }

        public void Save(Statement statement)
        {
            //Já está sendo salvo na criação do Customer
        }
    }
}
