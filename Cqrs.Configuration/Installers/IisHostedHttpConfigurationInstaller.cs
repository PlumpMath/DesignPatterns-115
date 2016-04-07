using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Cqrs.Configuration.Installers
{
    public class IisHostedHttpConfigurationInstaller : IHttpConfigurationInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<HttpConfiguration>().Instance(GlobalConfiguration.Configuration));
        }
    }
}
