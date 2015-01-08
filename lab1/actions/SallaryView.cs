using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Salary.Domain;
using Salary.Services;

namespace lab1.actions
{
    public class SallaryView : IAction
    {
        public EmployeeService EmployeeService;
        public PaymentService PaymentService;

        public SallaryView(IRepository<Employee> emplyeeRepository, IRepository<Timesheet> timesheetRepository)
		{
            EmployeeService = new EmployeeService(emplyeeRepository);
            PaymentService = new PaymentService(emplyeeRepository, timesheetRepository);
		}

		public void Perform(ActionExecutionContext context)
		{
			context.Out.WriteLine(ConsoleColor.Green, "\nЗарплата сотрудников");
		    var employees = EmployeeService.GetEmployees();
            foreach (var type in employees)
            {
                context.Out.Write(ConsoleColor.Yellow, "============\nИмя: ");
                context.Out.WriteLine(type.Name);
                context.Out.Write(ConsoleColor.Yellow, "Оклад: ");
                context.Out.WriteLine(type.Rate + " руб/час");
                context.Out.Write(ConsoleColor.Yellow, "З/п: ");
                context.Out.WriteLine(PaymentService.Payroll(type) + " руб.");
            }
		}
    }
}
