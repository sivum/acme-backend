using api.Handlers.Commands;
using api.Handlers.Responses;
using api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace api.Handlers
{
    public class RemoveEmployeeHandler: IRequestHandler<RemoveEmployeeCommand, GetEmployeesResponse>
    {
        private readonly IEmployeeService _employeeService;
        public RemoveEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<GetEmployeesResponse> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeService.RemoveEmployee(
                                request.EmployeeId);

            var employees = await _employeeService.GetEmployees();

            return new GetEmployeesResponse()
            {
                Employees = employees
            };
        }
    }
}
