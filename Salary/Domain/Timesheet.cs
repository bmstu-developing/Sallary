using System;

namespace Salary.Domain
{
    public class Timesheet : Entity
    {
        public Timesheet(Employee employee, DateTime date, decimal hours, bool overWork)
        {
            Employee = employee;
            Date = date;
            Hours = hours;
            OverWork = overWork;
        }

        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public bool OverWork { get; set; }
    }
}
