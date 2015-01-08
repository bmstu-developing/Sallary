using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary.Domain
{
    public class WorkedHours
    {
        public decimal HoursWorked;
        public decimal OverHoursWorked;

        public WorkedHours(decimal workedHours, decimal overWorkedHours)
        {
            HoursWorked = workedHours;
            OverHoursWorked = overWorkedHours;
        }

        public decimal GetPaymentForHours(decimal rage)
        {
            return HoursWorked*rage + OverHoursWorked*rage*2;
        }
    }
}
