using api.Handlers.Queries;
using api.Handlers.Responses;
using api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace api.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
    {
        private readonly IEmployeeService _employeeService;
        public GetEmployeesHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var response =  await _employeeService.GetEmployees();
            return new GetEmployeesResponse()
            {
                Employees = response
            };
        }
    }
}
