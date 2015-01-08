using System;

namespace Salary.Domain
{
    public class Sale : Entity
    {
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public decimal Summ { get; set; }

        public Sale(Employee employee, DateTime date, decimal summ)
        {
            Employee = employee;
            Date = date;
            Summ = summ;
        }
    }
}
