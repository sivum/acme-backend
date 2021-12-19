using api.ViewModel;
using System.Collections.Generic;

namespace api.Handlers.Responses
{
    public class GetEmployeesResponse
    {
        public IEnumerable<EmployeeView> Employees { get; set; }
    }
}
