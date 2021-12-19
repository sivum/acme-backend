using api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeView>> GetEmployees();
        Task<EmployeeView> GetEmployee(int employeeId);
        Task<EmployeeView> AddEmployee(string employeeNumber, string firstName, string lastName,
                            DateTime birthDate, DateTime employedDate);
        Task<EmployeeView> UpdateEmployee(int employeeId, string employeeNum, string firstName, string lastName,
                            DateTime birthDate, DateTime employedDate, DateTime? terminationDate);
        Task RemoveEmployee(int employeeId);
    }
}
