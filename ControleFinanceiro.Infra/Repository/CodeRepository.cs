using ControleFinanceiro.Domain.Entities.VlidationCode;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Infra.DataContexts;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace ControleFinanceiro.Infra.Repository
{
    public class CodeRepository : ICodeRepository
    {
        private readonly ControleFinanceiroContext _context;

        public CodeRepository(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public bool CheckCode(string code, Guid id)
        {
            return _context
                .Connection
                .Query<bool>("spCheckCode", new { code, id }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void MarkAsInvalid(string code, Guid id)
        {
            _context.Connection
                .Execute(
                    "update tblCode set Valid = 0 where CodeValue = @code and Id = @id", 
                    new {code, id},
                    commandType: CommandType.Text
                );
        }

        public void Save(Code code)
        {
            _context.Connection
                .Execute("insert into tblCode values (@Id, @CodeValue, @Valid, @Date)", 
                new { code.Id, code.CodeValue, code.Valid, code.Date }, 
                commandType: CommandType.Text
                );
        }
    }
}
