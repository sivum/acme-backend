using System;

namespace api.ViewModel
{
    public class EmployeeView
    {
        public int EmployeeId { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string EmployeeNum { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
