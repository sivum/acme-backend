using api.Handlers.Queries;
using api.Handlers.Responses;
using api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace api.Handlers
{
    public class GetEmployeeHandler: IRequestHandler<GetEmployeeQuery, GetEmployeeResponse>

    {
        private readonly IEmployeeService _employeeService;
        public GetEmployeeHandler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<GetEmployeeResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = await _employeeService.GetEmployee(request.EmployeeId);
            return new GetEmployeeResponse()
            {
                Employee = response
            };
        }
    }
   
}
