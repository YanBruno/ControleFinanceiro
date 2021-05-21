using ControleFinanceiro.Domain.Entities.VlidationCode;
using System;

namespace ControleFinanceiro.Domain.Repositories.Contracts
{
    public interface ICodeRepository
    {
        public void Save(Code code);
        public bool CheckCode(string code, Guid id);
        public void MarkAsInvalid(string code, Guid id);
    }
}
