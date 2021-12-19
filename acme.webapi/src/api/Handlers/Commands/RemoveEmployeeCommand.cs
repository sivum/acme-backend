using api.Handlers.Responses;
using MediatR;

namespace api.Handlers.Commands
{
    public class RemoveEmployeeCommand: IRequest<GetEmployeesResponse>
    {
        public int EmployeeId { get; set; }
    }
}
