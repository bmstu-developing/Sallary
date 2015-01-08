using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Salary.Api;
using Salary.Data;
using Salary.Domain;
using Salary.Services;

namespace Salary.Installer
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof (IRepository<>)).ImplementedBy(typeof (Data.Data<>)));
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<SalaryApi>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<AwardService>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<EmployeeService>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<PaymentService>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<SaleService>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<TimesheetService>());
            container.Register(Component.For<DataGenerator>());
        }
    }
}
