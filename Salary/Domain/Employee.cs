using System;

namespace Salary.Domain
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Contacts { get; set; }
        public int Rate { get; set; }
        public Position Position { get; set; }

        public Employee(string name, string contacts, int rate, Position position)
        {
            Name = name;
            Contacts = contacts;
            Rate = rate;
            Position = position;
        }

        public Timesheet CreateTimesheet(DateTime date, decimal hours, bool overWork)
        {
            return new Timesheet(this, date, hours, overWork);
        }
    }
}
