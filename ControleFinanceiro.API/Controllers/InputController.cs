using ControleFinanceiro.Domain.Commands.Contracts;
using ControleFinanceiro.Domain.Commands.Input;
using ControleFinanceiro.Domain.Handlers;
using ControleFinanceiro.Domain.Queries;
using ControleFinanceiro.Domain.Queries.Results;
using ControleFinanceiro.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ControleFinanceiro.API.Controllers
{
    [Route("v1/customers/inputs/")]
    public class InputController : Controller
    {
        private readonly InputHandler _handler;
        private readonly IInputRepository _repository;

        public InputController(InputHandler handler, IInputRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        [Authorize]
        [Route("credit")]
        public ICommandResult CreditPost([FromBody] CreateCreditCommand command)
        {
            command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            return _handler.Handle(command);
        }

        [HttpPost]
        [Authorize]
        [Route("debit")]
        public ICommandResult DebitPost([FromBody] CreateDebitCommand command)
        {
            command.CustomerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            return _handler.Handle(command);
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<InputQueryResult> GetAll([FromQuery]bool done)
        {
            var customerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            return _repository.Get(customerId);
        }

        [HttpGet]
        [Authorize]
        [Route("{type}")]
        public IEnumerable<InputQueryResult> GetByType(string type)
        {
            var customerId = Guid.Parse(User.FindFirst(ClaimTypes.Sid)?.Value);
            return _repository.Get(customerId)
                .AsQueryable()
                .Where(
                    new InputQueries()
                        .QueryType(type)
                        .Apply()
                );
        }
    }
}