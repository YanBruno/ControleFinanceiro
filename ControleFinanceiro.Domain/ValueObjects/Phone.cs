using ControleFinanceiro.Shared.ValueObjects.Contracts;

namespace ControleFinanceiro.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public Phone(string dDD, string number)
        {
            DDD = dDD;
            Number = number;
            CountryCode = "55";
        }

        public string CountryCode { get; private set; }
        public string DDD { get; private set; }
        public string Number { get; private set; }

        public override string ToString()
        {
            return $"{CountryCode}{DDD}{Number}";
        }
    }
}
