using System;
using Feonufry.CUI.Actions;
using Salary.Services;

namespace lab1.actions
{
    public class ShowPayments : IAction
    {
        public EmployeeService EmployeeService;
        public PaymentService PaymentService;
        public TimesheetService TimesheetService;

        public ShowPayments(EmployeeService employeeService, PaymentService paymentService, TimesheetService timesheetService)
        {
            EmployeeService = employeeService;
            PaymentService = paymentService;
            TimesheetService = timesheetService;
        }

        public void Perform(ActionExecutionContext context)
		{
			context.Out.WriteLine(ConsoleColor.Green, "\nЗарплата сотрудников");
		    var employees = EmployeeService.GetEmployees();
            foreach (var employee in employees)
            {
                context.Out.Write(ConsoleColor.Yellow, "============\nИмя: ");
                context.Out.WriteLine(employee.Name);
                context.Out.Write(ConsoleColor.Yellow, "Оклад: ");
                context.Out.WriteLine(employee.Rate + " руб/час");
                context.Out.Write(ConsoleColor.Yellow, "Процентная ставка: ");
                context.Out.WriteLine(employee.Position.Percent*100 + "% ");
                context.Out.WriteLine(ConsoleColor.Yellow, "Выплаты: ");
                var payments = PaymentService.GetListByEmployeeId(employee.Id);
                foreach (var payment in payments)
                {
                    context.Out.Write(ConsoleColor.Blue, "Начало периода оплаты: ");
                    context.Out.WriteLine(payment.DateFrom.ToShortDateString());
                    context.Out.Write(ConsoleColor.Blue, "Конец периода оплаты: ");
                    context.Out.WriteLine(payment.DateTo.ToShortDateString());
                    context.Out.Write(ConsoleColor.Blue, "Отработано часов: ");
                    context.Out.WriteLine(PaymentService.GetWorkedHours(employee.Id, payment.DateFrom, payment.DateTo).HoursWorked.ToString());
                    context.Out.Write(ConsoleColor.Blue, "Переработано часов: ");
                    context.Out.WriteLine(PaymentService.GetWorkedHours(employee.Id, payment.DateFrom, payment.DateTo).OverHoursWorked.ToString());
                    context.Out.Write(ConsoleColor.Blue, "Общая сумма выплаты: ");
                    context.Out.WriteLine(ConsoleColor.Red, payment.Summ.ToString());
                    context.Out.Write(ConsoleColor.Blue, "Информация по выплате: ");
                    context.Out.WriteLine(payment.Information);
                }
            }
		}
    }
}
