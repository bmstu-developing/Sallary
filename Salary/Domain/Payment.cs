using System;

namespace Salary.Domain
{
    public class Payment : Entity
    {
        public Payment(Employee employee, DateTime date, DateTime dateFrom, DateTime dateTo, decimal summ, string information)
        {
            Employee = employee;
            Date = date;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Summ = summ;
            Tax = summ*0.13m;
            Information = information;
        }

        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal Summ { get; set; }
        public decimal Tax { get; set; }
        public string Information { get; set; }
    }
}
