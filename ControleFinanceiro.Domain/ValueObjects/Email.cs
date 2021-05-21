using ControleFinanceiro.Shared.ValueObjects.Contracts;

namespace ControleFinanceiro.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return $"{Address}";
        }
    }
}
