using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary.Domain;

namespace Salary.Services
{
    public class AwardService
    {
        private readonly IRepository<Award> _awardRepository;
        private readonly IRepository<Employee> _employeesRepository; 

        public AwardService(IRepository<Award> awardRepository, IRepository<Employee> employeeRepository)
        {
            _awardRepository = awardRepository;
            _employeesRepository = employeeRepository;
        }

        private Employee GetEmployeeById(Guid employeeId)
        {
            return _employeesRepository.Get(employeeId);
        }

        public void AddAward(Guid employeeId, DateTime date, decimal summ, string description)
        {
            _awardRepository.Add(new Award(GetEmployeeById(employeeId), date, summ, description));
        }
    }
}
