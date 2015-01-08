using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Salary.Domain;
using Salary.Services;

namespace lab1.actions
{
    public class CreateSale : IAction
    {
        public EmployeeService EmployeeService;
        public SaleService SaleService;

        public CreateSale(EmployeeService employeeService, SaleService saleService)
        {
            EmployeeService = employeeService;
            SaleService = saleService;
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
                    ctx => ContinueSaleCreation(ctx, employeeId));
            }
            submenuBuilder.GetMenu().Run();
        }

        private void ContinueSaleCreation(ActionExecutionContext context, Guid employeeId)
        {
            context.Out.Write(ConsoleColor.Blue, "Введите сумму продажи: ");
            var summ = context.In.ReadDecimal();
            var employee = EmployeeService.GetEmployeeById(employeeId);
            context.Out.Write(ConsoleColor.Blue, "Введите дату продажи (dd-mm-yyyy): ");
            var date = context.In.ReadLine();
            DateTime dateResult;
            DateTime.TryParse(date, out dateResult);
            SaleService.AddSale(employee, dateResult, summ);
        }
    }
}
