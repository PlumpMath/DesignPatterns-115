using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cqrs.Application;
using Cqrs.Application.Executors.Commands;

namespace Cqrs.Configuration.Installers
{
    public class CommandsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ICommandExecutor>().ImplementedBy<CommandExecutor>().LifestyleTransient(),
                Component.For<ICommandHandlerFactory>().AsFactory().LifestyleTransient());

            container.Register(
                Classes
                    .FromAssemblyContaining<IApplicationAssemblyMarker>()
                    .BasedOn(typeof(ICommandHandler))
                    .WithServiceFirstInterface()
                    .LifestyleTransient());
           
        }
    }
}
