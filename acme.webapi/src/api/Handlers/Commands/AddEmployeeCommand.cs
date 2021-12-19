using api.Handlers.Responses;
using MediatR;
using System;

namespace api.Handlers.Commands
{
    public class AddEmployeeCommand: IRequest<GetEmployeeResponse>
    {
        public string EmployeeNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmployedDate { get; set; }

    }
}
