using ControleFinanceiro.Domain.Commands.Contracts;

namespace ControleFinanceiro.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
