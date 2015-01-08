using System;
using System.Collections.Generic;
using System.Linq;
using Salary.Domain;

namespace Salary.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeesRepository;

        public EmployeeService(IRepository<Employee> employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public List<Employee> GetEmployees()
        {
            return _employeesRepository.AsQueryable().ToList();
        }

        public Employee GetEmployeeById(Guid employeeId)
        {
            return _employeesRepository.Get(employeeId);
        }
    }
}
