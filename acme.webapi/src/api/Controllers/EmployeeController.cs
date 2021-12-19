using System;
using System.Threading.Tasks;
using api.Handlers.Commands;
using api.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IMediator _bus;
        public EmployeeController(IMediator mediatr)
        {
            _bus = mediatr;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] AddEmployeeCommand command)
        {
            var response = await _bus.Send(command);
            return Created($"/api/employee/employee/{response.Employee.EmployeeId}",response);
        }

      
        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> Get()
        {
            var response = await _bus.Send(new GetEmployeesQuery());
            return Ok(response.Employees);
        }

        [HttpGet]
        [Route("employee/{employeeId}")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {
            var response = await _bus.Send(new GetEmployeeQuery() { EmployeeId = employeeId });
            return Ok(response.Employee);
        }

        [HttpPost]
        [Route("employee/update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand command)
        {
            var response = await _bus.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Route("employee/remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveEmployeeCommand command)
        {
            var response = await _bus.Send(command);
            return Ok(response);
        }
    }
}
