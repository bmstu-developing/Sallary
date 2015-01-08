using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Salary.Domain;
using Salary.Services;

namespace lab1.actions
{
    public class CreateTimesheet : IAction
    {
        public EmployeeService EmployeeService;
        public TimesheetService TimesheetService;

        public CreateTimesheet(EmployeeService employeeService, TimesheetService timesheetService)
        {
            EmployeeService = employeeService;
            TimesheetService = timesheetService;
        }

        public void Perform(ActionExecutionContext context)
        {
            var submenuBuilder = new MenuBuilder()
               .RunnableOnce();
            var employees = EmployeeService.GetEmployees();
            foreach (var employee in employees)
            {
                var employeeId = employee.Id;
                submenuBuilder.Item(
                    string.Format("{0}", employee.Name),
                    ctx => ContinueTimesheetCreation(ctx, employeeId));
            }
            submenuBuilder.GetMenu().Run();
        }

        public void ContinueTimesheetCreation(ActionExecutionContext context, Guid employeeId)
        {
            var employee = EmployeeService.GetEmployeeById(employeeId);
            context.Out.WriteLine("Введите количество отработанных часов: ");
            decimal hours = context.In.ReadDecimal();
            context.Out.WriteLine("Введите дату отработки (dd-mm-yyyy): ");
            var date = context.In.ReadLine();
            DateTime dateResult;
            bool tryParse = DateTime.TryParse(date, out dateResult);
            context.Out.WriteLine("Это переработка? (1/0) ");
            var overWork = context.In.ReadInt32() == 1;
            TimesheetService.AddTimesheet(employee, dateResult, hours, overWork);
        }
    }
}
