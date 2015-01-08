using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Feonufry.CUI.Actions;

namespace lab1.Installer
{
    public class UIInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container = container.Register(Classes.FromThisAssembly().BasedOn<IAction>().WithServiceSelf());
        }
    }
}
