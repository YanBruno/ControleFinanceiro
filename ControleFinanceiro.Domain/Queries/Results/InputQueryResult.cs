using System;

namespace ControleFinanceiro.Domain.Queries.Results
{
    public class InputQueryResult
    {
        public InputQueryResult()
        {
        }

        public InputQueryResult(Guid id, string type, double value, string description, DateTime dueDate, DateTime inputDate, bool done, Guid statementId)
        {
            Id = id;
            Type = type;
            Value = value;
            Description = description;
            DueDate = dueDate;
            InputDate = inputDate;
            Done = done;
            StatementId = statementId;
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime InputDate { get; set; }
        public bool Done { get; set; }
        public Guid StatementId { get; set; }
    }
}
