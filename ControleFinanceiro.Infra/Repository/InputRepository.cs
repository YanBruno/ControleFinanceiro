using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Inputs.Contracts;
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.Queries.Results;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Infra.DataContexts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace ControleFinanceiro.Infra.Repository
{
    public class InputRepository : IInputRepository
    {
        private readonly ControleFinanceiroContext _context;

        public InputRepository(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public IEnumerable<InputQueryResult> Get(Guid customerId)
        {
            return  
                _context.Connection.Query<InputQueryResult>(
                    "spGetInputsByCustomer", 
                    new { CustomerId = customerId}, 
                    commandType: CommandType.StoredProcedure
                );
        }
        public void Save(Input input)
        {
            //_context.Connection.Execute(
            //    "spCreateInput",
            //    new
            //    {
            //        input.Id,
            //        input.Type,
            //        input.Value,
            //        input.Description,
            //        input.DueDate,
            //        input.InputDate,
            //        input.Done,
            //    },
            //    commandType: CommandType.StoredProcedure);
        }
        public void SaveFromStatement(Statement statement)
        {
            foreach (var input in statement.Inputs)
            {
                _context.Connection.Execute(
                    "spCreateInputFromStatement",
                    new
                    {
                        input.Id,
                        input.Type,
                        input.Value,
                        input.Description,
                        input.DueDate,
                        input.InputDate,
                        input.Done,
                        StatementId = statement.Id
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}