using System;
using Feonufry.CUI.Actions;
using Salary.Services;

namespace lab1
{
    public class AllEmployees : IAction 
    {
        public EmployeeService EmployeeService;

        public AllEmployees(EmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        public void Perform(ActionExecutionContext context)
		{
			context.Out.WriteLine(ConsoleColor.Green, "\nСотрудники");
		    var employees = EmployeeService.GetEmployees();
			foreach (var type in employees)
			{
                context.Out.Write(ConsoleColor.Yellow, "============\nИмя: ");
                context.Out.WriteLine(type.Name);
                context.Out.Write(ConsoleColor.Yellow, "Контактная информация: ");
                context.Out.WriteLine(type.Contacts);
                context.Out.Write(ConsoleColor.Yellow, "Должность: ");
                context.Out.WriteLine(type.Position.Name);
                context.Out.Write(ConsoleColor.Yellow, "Оклад: ");
                context.Out.WriteLine(type.Rate + " руб/час");
                context.Out.Write(ConsoleColor.Yellow, "Категория: ");
                context.Out.WriteLine(type.Position.Category.ToString());
                context.Out.Write(ConsoleColor.Yellow, "Процент от продаж: ");
                context.Out.WriteLine(type.Position.Percent * 100 + "%");
			}
		}
    }        
}
