using ControleFinanceiro.Domain.Commands;
using ControleFinanceiro.Domain.Commands.Contracts;
using ControleFinanceiro.Domain.Commands.Input;
using ControleFinanceiro.Domain.Entities.Inputs;
using ControleFinanceiro.Domain.Handlers.Contracts;
using ControleFinanceiro.Domain.Repositories.Contracts;

namespace ControleFinanceiro.Domain.Handlers
{
    public class InputHandler :
        IHandler<CreateDebitCommand>,
        IHandler<CreateCreditCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IStatementRepository _statementRepository;
        private readonly IInputRepository _inputRepository;

        public InputHandler(ICustomerRepository customerRepository, IStatementRepository statementRepository, IInputRepository inputRepository)
        {
            _customerRepository = customerRepository;
            _statementRepository = statementRepository;
            _inputRepository = inputRepository;
        }

        public ICommandResult Handle(CreateDebitCommand command)
        {
            //Validar command


            //Recuperar customer
            var customer = _customerRepository.GetById(command.CustomerId);

            //Validar customer


            //Criar VO's


            //Criar Entidades
            var debit = new Debit(command.Value, command.Description, command.DueDate);
            customer.Statement.AddInput(debit);

            //Validar VO's e entidades


            //Persistir no banco
            _inputRepository.SaveFromStatement(customer.Statement);

            //Retonar valor
            return new GenericCommandResult(true, "Débito adicionado com sucesso", debit);

        }
        public ICommandResult Handle(CreateCreditCommand command)
        {
            //Validar command


            //Recuperar customer
            var customer = _customerRepository.GetById(command.CustomerId);

            //Validar customer


            //Criar VO's


            //Criar Entidades
            var credit = new Credit(command.Value, command.Description, command.DueDate);
            customer.Statement.AddInput(credit);

            //Validar VO's e entidades


            //Persistir no banco
            _inputRepository.SaveFromStatement(customer.Statement);

            //Retonar valor
            return new GenericCommandResult(true, $"Crédito adicionado com sucesso", credit);
        }

    }
}
