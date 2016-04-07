using System.Linq;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.Facilities.TypedFactory.Internal;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Cqrs.Configuration.Installers
{
    public class FacilitiesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.AddFacility<TypedFactoryFacility>();
            container.Kernel.GetHandlers(typeof(TypedFactoryInterceptor)).First().ComponentModel.LifestyleType = LifestyleType.Singleton;
        }
    }
}
