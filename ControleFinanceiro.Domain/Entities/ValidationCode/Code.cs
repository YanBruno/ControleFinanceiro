using System;

namespace ControleFinanceiro.Domain.Entities.VlidationCode
{
    public class Code
    {
        public Code(Guid id)
        {
            Id = id;
            CodeValue = new Random().Next(100000, 999999).ToString();
            Valid = true;
            Date = DateTime.Now;

        }

        public Guid Id { get; private set; }
        public string CodeValue { get; private set; }
        public bool Valid { get; private set; }
        public DateTime Date { get; private set; }

        public void MarkAsInvalid()
        {
            Valid = false;
        }
    }
}
