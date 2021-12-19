using api.Handlers.Responses;
using MediatR;
using System;

namespace api.Handlers.Commands
{
    public class UpdateEmployeeCommand : IRequest<GetEmployeeResponse>
    {
        public int EmployeeId { get; set; }
        public string EmployeeNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
