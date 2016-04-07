using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cqrs.Application;
using Cqrs.Application.Executors.Queries;

namespace Cqrs.Configuration.Installers
{
    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register
                (
                    Component.For<IQueryExecutor>().ImplementedBy<QueryExecutor>().LifestyleTransient(),
                    Component.For<IQueryFactory>().AsFactory().LifestyleTransient()
                );

            container.Register(

                Classes
                    .FromAssemblyContaining<IApplicationAssemblyMarker>()
                    .BasedOn(typeof(IQuery))
                    .WithServiceAllInterfaces()
                    .LifestyleTransient()
                );
        }
    }
}
