using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cqrs.Web.Controllers;

namespace Cqrs.Web.Configuration
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IControllerFactory>().ImplementedBy<WindsorControllerFactory>().LifestyleTransient());

            // Register all controllers from this assembly
            container.Register(Classes.FromAssembly(typeof(BaseController).Assembly)
                .BasedOn<Controller>()
                .LifestyleTransient());
        }
    }
}