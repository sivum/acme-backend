using api.Handlers.Commands;
using api.Handlers.Responses;
using api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace api.Handlers
{
    public class UpdateEmployeeHandler: IRequestHandler<UpdateEmployeeCommand, GetEmployeeResponse>
    {
        private readonly IEmployeeService _employeeService;
        public UpdateEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<GetEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.UpdateEmployee(
                                request.EmployeeId,
                                request.EmployeeNum,
                                request.FirstName,
                                request.LastName,
                                request.BirthDate,
                                request.EmployedDate,
                                request.TerminationDate);

            return new GetEmployeeResponse()
            {
                Employee = employee
            };
        }
    }
}
