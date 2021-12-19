using api.Data;
using api.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class EmployeeService : IEmployeeService
    {
       
        private readonly IDbContextFactory<EmployeeContext> _dbContextFactory;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(IDbContextFactory<EmployeeContext> dbContextFactory,ILogger<EmployeeService> logger)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<EmployeeView> AddEmployee(string employeeNumber, string firstName, string lastName,DateTime birthDate,DateTime employedDate)
        {
            var person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };
            var employee = new Employee()
            {
                EmployeeNum = employeeNumber,
                Person = person,
                EmployedDate = employedDate,
            };

            await using var auditContext = _dbContextFactory.CreateDbContext();
            try
            {
                await auditContext.Employee.AddAsync(employee);
                await auditContext.SaveChangesAsync();
                return new EmployeeView()
                {
                    EmployeeId = person.Employee.EmployeeId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.BirthDate,
                    EmployeeNum = person.Employee.EmployeeNum,
                    TerminationDate = person.Employee.Terminated
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while calling {0}", nameof(AddEmployee));
                throw;
            }
        }

        public async Task<EmployeeView> GetEmployee(int employeeId)
        {
            await using var auditContext = _dbContextFactory.CreateDbContext();
            try
            {
                var model = await auditContext.Employee.Where(n => n.EmployeeId == employeeId)
                            .Include(n=>n.Person)
                            .SingleOrDefaultAsync();
                return new EmployeeView()
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.Person.FirstName,
                    LastName = model.Person.LastName,
                    BirthDate = model.Person.BirthDate,
                    EmployeeNum = model.EmployeeNum,
                    TerminationDate = model.Terminated,
                    EmploymentDate = model.EmployedDate
                }; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while calling {0}", nameof(GetEmployee));
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeView>> GetEmployees()
        {
            await using var auditContext = _dbContextFactory.CreateDbContext();
            try
            {
                var model = await auditContext.Employee
                            .Include(n=>n.Person)
                            .ToListAsync();
                return model.Select(n => new EmployeeView()
                {
                    EmployeeId = n.EmployeeId,
                    FirstName = n.Person.FirstName,
                    LastName = n.Person.LastName,
                    BirthDate = n.Person.BirthDate,
                    EmployeeNum = n.EmployeeNum,
                    TerminationDate = n.Terminated
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while calling {0}", nameof(GetEmployees));
                throw;
            }
        }

        public async Task RemoveEmployee(int employeeId)
        {
            await using var auditContext = _dbContextFactory.CreateDbContext();
            try
            {
                var model = await auditContext.Employee.Where(n => n.EmployeeId == employeeId)
                            .Include(n=>n.Person)
                            .SingleOrDefaultAsync();
                auditContext.Remove(model.Person);
                await  auditContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while calling {0}", nameof(RemoveEmployee));
                throw;
            }
        }

        public async Task<EmployeeView> UpdateEmployee(int employeeId, string employeeNum, string firstName, string lastName, 
                                        DateTime birthDate, DateTime employedDate, DateTime? terminationDate)
        {
            await using var auditContext = _dbContextFactory.CreateDbContext();
            try
            {
                var model = await auditContext.Employee.Where(n => n.EmployeeId == employeeId)
                                    .Include(n=>n.Person)
                                    .SingleOrDefaultAsync();
                model.Person.FirstName = firstName;
                model.Person.LastName = lastName;
                model.Person.BirthDate = birthDate;
                model.EmployeeNum = employeeNum;
                model.EmployedDate = employedDate;
                model.Terminated = terminationDate;
                await auditContext.SaveChangesAsync();

                return new EmployeeView()
                {
                    EmployeeId = model.EmployeeId,
                    FirstName = model.Person.FirstName,
                    LastName = model.Person.LastName,
                    BirthDate = model.Person.BirthDate,
                    EmployeeNum = model.EmployeeNum,
                    TerminationDate = model.Terminated
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error while calling {0}", nameof(UpdateEmployee));
                throw;
            }
        }
    }
}
