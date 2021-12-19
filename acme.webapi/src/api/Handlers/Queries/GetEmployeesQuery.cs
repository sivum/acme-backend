using api.Handlers.Responses;
using MediatR;

namespace api.Handlers.Queries
{
    public class GetEmployeesQuery: IRequest<GetEmployeesResponse>
    {
    }
}
