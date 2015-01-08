using Feonufry.CUI.Menu.Builders;
using Castle.Windsor;
using lab1.Installer;
using Salary.Data;
using Salary.Installer;
using lab1.actions;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new CoreInstaller(), new UIInstaller());
            var generator = container.Resolve<DataGenerator>();
            generator.Generate();

            new MenuBuilder()
               .WithActionFactory(new WindsorActionFactory(container))
               .Title("Payment program\n v0.1\nГлавное меню")
               .Prompt("Введите команду")
               .Item<AllEmployees>("Просмотреть список сотрудников")
               .Item<ShowPayments>("Вывести зарплатные квитанции")
               .Item<CreateTimesheet>("Создать отчет о рабочем времени")
               .Item<CreateSale>("Создать продажу")
               .Item<CreateAward>("Выписать премию")
               .Item<CreatePayment>("Создать квитанцию о выплате")
               .Exit("Выйти")
               .GetMenu()
               .Run();
        }
    }
}
