using System;

namespace Salary.Domain
{
    public class Award : Entity
    {
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public decimal Summ { get; set; }
        public string Description { get; set; }

        public Award(Employee employee, DateTime date, decimal summ, string description)
        {
            Employee = employee;
            Date = date;
            Summ = summ;
            Description = description;
        }
    }
}
