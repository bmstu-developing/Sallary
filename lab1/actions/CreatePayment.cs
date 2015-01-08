
using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Salary.Domain;
using Salary.Services;

namespace lab1.actions
{
    public class CreatePayment :IAction
    {
        public PaymentService PaymentService;
        public EmployeeService EmployeeService;

        public CreatePayment(PaymentService paymentService, EmployeeService employeeService)
        {
            PaymentService = paymentService;
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
                    ctx => ContinuePaymentCreation(ctx, employeeId));
            }
            submenuBuilder.GetMenu().Run();
        }

        public void ContinuePaymentCreation(ActionExecutionContext context, Guid employeeId)
        {
            var employee = EmployeeService.GetEmployeeById(employeeId);
            context.Out.Write(ConsoleColor.Blue, "Введите дату начала периода (dd-mm-yyyy): ");
            var date1 = context.In.ReadLine();
            context.Out.Write(ConsoleColor.Blue, "Введите дату конца периода (dd-mm-yyyy): ");
            var date2 = context.In.ReadLine();
            DateTime dateResult1;
            DateTime.TryParse(date1, out dateResult1);
            DateTime dateResult2;
            DateTime.TryParse(date2, out dateResult2);
            context.Out.Write(ConsoleColor.Blue, "Введите информацию о выплате");
            var info = context.In.ReadLine();
            var summ = PaymentService.Payroll(employee.Id, dateResult1, dateResult2);
            PaymentService.AddPayment(employee.Id, DateTime.Now, dateResult1, dateResult2, summ, info);
        }
    }
}
