using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Salary.Domain;
using Salary.Services;

namespace lab1.actions
{
    public class CreateAward : IAction
    {
        public AwardService AwardService;
        public EmployeeService EmployeeService;

        public CreateAward(AwardService awardService, EmployeeService employeeService)
        {
            AwardService = awardService;
            EmployeeService = employeeService;
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
                    ctx => ContinueAwardCreation(ctx, employeeId));
            }
            submenuBuilder.GetMenu().Run();
        }

        public void ContinueAwardCreation(ActionExecutionContext context, Guid employeeId)
        {
            context.Out.Write(ConsoleColor.Blue, "Введите сумму премии: ");
            var summ = context.In.ReadDecimal();
            var employee = EmployeeService.GetEmployeeById(employeeId);
            context.Out.Write(ConsoleColor.Blue, "Введите дату премии (dd-mm-yyyy): ");
            var date = context.In.ReadLine();
            context.Out.Write(ConsoleColor.Blue, "Описание");
            var description = context.In.ReadLine();
            DateTime dateResult;
            DateTime.TryParse(date, out dateResult);
            AwardService.AddAward(employeeId, dateResult, summ, description);
        }
    }
}
