using api.Handlers.Commands;
using api.Handlers.Responses;
using api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace api.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeCommand, GetEmployeeResponse>
    {
        private readonly IEmployeeService _employeeService;
        public AddEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<GetEmployeeResponse> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.AddEmployee(
                                request.EmployeeNum,
                                request.FirstName,
                                request.LastName,
                                request.BirthDate,
                                request.EmploymentDate);
            return new GetEmployeeResponse()
            {
                Employee = employee
            };
        }
    }
}
