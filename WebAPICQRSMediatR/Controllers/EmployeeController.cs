using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPICQRSMediatR.Data;
using WebAPICQRSMediatR.Data.Command;
using WebAPICQRSMediatR.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICQRSMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> EmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _mediator.Send(new CreateEmployeeCommand(
               employee.Name,
               employee.Email,
               employee.Address,
               employee.Phone));

            return result;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<int> Update(Employee employee)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(
              employee.Id,
              employee.Name,
              employee.Email,
              employee.Address,
              employee.Phone));

            return result;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
           return await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
        }
    }
}
