using ControleFinanceiro.Domain.Commands.Contracts;

namespace ControleFinanceiro.Domain.Commands.Customer
{
    public class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand()
        {
        }

        public CreateCustomerCommand(string firstName, string lastName, string emailAddress, string countryCode, string phoneDDD, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CountryCode = countryCode;
            PhoneDDD = phoneDDD;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CountryCode { get; set; }
        public string PhoneDDD { get; set; }
        public string PhoneNumber { get; set; }

        public void Validate()
        {
            
        }
    }
}
