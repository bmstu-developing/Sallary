using System;
using System.Linq;
using Salary.Domain;

namespace Salary.Services
{
    public class TimesheetService
    {
        private readonly IRepository<Timesheet> _timesheetRepository;

        public TimesheetService(IRepository<Timesheet> timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public void AddTimesheet(Employee employee, DateTime date, decimal hours, bool over)
        {
            _timesheetRepository.Add(new Timesheet(employee, date, hours, over));
        }

    }
}
