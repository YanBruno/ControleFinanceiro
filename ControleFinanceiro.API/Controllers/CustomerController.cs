using ControleFinanceiro.Domain.Commands.Contracts;
using ControleFinanceiro.Domain.Commands.Customer;
using ControleFinanceiro.Domain.Entities.Customer;
using ControleFinanceiro.Domain.Handlers;
using ControleFinanceiro.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleFinanceiro.API.Controllers
{
    [Route("v1/customers/")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        //[HttpGet]
        //[Authorize]
        ////[ResponseCache(Duration = 15)]
        //public IEnumerable<CustomerQueryResult> Get()
        //{
        //    return _repository.GetAll();
        //}

        [HttpGet]
        [Route("Code")]
        [AllowAnonymous]
        public ICommandResult GetCode([FromBody]GenerateCustomerCodeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ICommandResult Authentication([FromBody]AuthenticateCustomerCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public ICommandResult CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public Customer GetById(Guid id)
        {
            return _repository.GetById(id);
        }
    }
}
