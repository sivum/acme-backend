using api.Handlers.Responses;
using MediatR;

namespace api.Handlers.Queries
{
    public class GetEmployeeQuery: IRequest<GetEmployeeResponse>
    {
        public int EmployeeId { get; set; }
    }
}
