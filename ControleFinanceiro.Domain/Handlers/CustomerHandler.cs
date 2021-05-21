using ControleFinanceiro.Domain.Commands;
using ControleFinanceiro.Domain.Commands.Contracts;
using ControleFinanceiro.Domain.Commands.Customer;
using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Entities.Statements;
using ControleFinanceiro.Domain.Entities.VlidationCode;
using ControleFinanceiro.Domain.Handlers.Contracts;
using ControleFinanceiro.Domain.Repositories.Contracts;
using ControleFinanceiro.Domain.Services.Contracts;
using ControleFinanceiro.Domain.ValueObjects;

namespace ControleFinanceiro.Domain.Handlers
{
    public class CustomerHandler :
        IHandler<CreateCustomerCommand>,
        IHandler<GenerateCustomerCodeCommand>,
        IHandler<AuthenticateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        private readonly ICodeRepository _codeRepository;
        private readonly ISmsService _smsService;
        private readonly ITokenService _tokenService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService, ICodeRepository codeRepository, ISmsService smsService, ITokenService tokenService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
            _codeRepository = codeRepository;
            _smsService = smsService;
            _tokenService = tokenService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Validar command
            command.Validate();

            //Confere email
            if(_customerRepository.CheckEmail(command.EmailAddress))
                return new GenericCommandResult(false, "Este e-mail já está em uso", null);

            //Confere phone
            if(_customerRepository.CheckPhone(command.CountryCode, command.PhoneDDD, command.PhoneNumber))
                return new GenericCommandResult(false, "Este telefone já está em uso", null);

            //VO's
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.EmailAddress);
            var phone = new Phone(command.PhoneDDD, command.PhoneNumber);

            //Entidades
            var statement = new Statement("Personal");
            var customer = new Customer(name, email, phone, statement);

            //Validar VO's e Entidades


            //Persistir no banco
            _customerRepository.Save(customer);

            //Aplicar serviços
            _emailService.Send(email, "Bem vindo a plataforma", "Aqui você conseguirá controlar sua movimentação financeira!");
            var token = _tokenService.GenerateToken(customer);

            return new GenericCommandResult(true, "Usuário criado com sucesso,", new { customer, token });
        }

        public ICommandResult Handle(GenerateCustomerCodeCommand command)
        {
            //Validar command
            command.Validate();

            if (!_customerRepository.CheckEmail(command.Email))
                return new GenericCommandResult();

            var customer = _customerRepository.GetByEmail(command.Email);

            //Criar entidades
            var code = new Code(customer.Id);

            //Persistir no banco
            _codeRepository.Save(code);

            //Enviar sms
            _smsService.Send(customer.Phone, $"Codigo plataforma Controle Financeiro:\n\n{code.CodeValue}\n\n\n");

            return new GenericCommandResult(true, $"Código de validação enviado para o numero {customer.Phone}", null);
        }

        public ICommandResult Handle(AuthenticateCustomerCommand command)
        {
            //Validar command
            command.Validate();

            //Validar command
            command.Validate();

            if (!_customerRepository.CheckEmail(command.Email))
                return new GenericCommandResult();

            var customer = _customerRepository.GetByEmail(command.Email);

            if(!_codeRepository.CheckCode(command.Code, customer.Id))
                return new GenericCommandResult(false, "Código inválido", null);

            var token = _tokenService.GenerateToken(customer);

            _codeRepository.MarkAsInvalid(command.Code, customer.Id);

            return new GenericCommandResult(true, "Validação concluída", new { token });
        }
    }
}
