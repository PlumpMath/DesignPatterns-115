using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Cqrs.Configuration;
using Cqrs.Configuration.Installers;
using Cqrs.Configuration.StartupTasks;
using Owin;

namespace Cqrs.Web.Configuration
{
    public class DefaultContainer : WindsorContainer
    {
        public void Configuration(IAppBuilder app)
        {
            var container = CreateIisHostedContainer();
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            var tasks = container.ResolveAll<IStartupTask>();
            foreach (var startupTask in tasks)
            {
                startupTask.Run();
            }
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }


        public IWindsorContainer CreateIisHostedContainer()
        {
            var container = new WindsorContainer();

            container.Install(
                WindsorInstallers.Builder()
                    .Include<IisHostedHttpConfigurationInstaller, IHttpConfigurationInstaller>()
                    .Include<ControllersInstaller>()
                    .Include(GetType().Assembly)
                    .Include(typeof(IConfigurationMarker).Assembly)
                    .OrderFirst<FacilitiesInstaller>());

            return container;
        }
    }
}