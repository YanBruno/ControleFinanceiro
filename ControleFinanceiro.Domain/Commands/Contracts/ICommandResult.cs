﻿namespace ControleFinanceiro.Domain.Commands.Contracts
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
        object Data { get; }
    }
}
