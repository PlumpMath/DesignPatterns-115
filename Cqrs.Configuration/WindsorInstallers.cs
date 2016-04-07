using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.MicroKernel.Registration;

namespace Cqrs.Configuration
{
    public class WindsorInstallers
    {
        private class Installer
        {
            private readonly Func<IWindsorInstaller> _create;
            private readonly Type _installerType;

            private Installer(Type installerType, Func<IWindsorInstaller> create)
            {
                _installerType = installerType;
                _create = create;
            }

            public static Installer Create(Type installerType, Func<IWindsorInstaller> create)
            {
                return new Installer(installerType, create);
            }

            public static Installer Create<T>(Func<IWindsorInstaller> create)
            {
                return new Installer(typeof(T), create);
            }

            public IWindsorInstaller Create()
            {
                return _create();
            }

            public Type InstallerType
            {
                get { return _installerType; }
            }
        }

        private IEnumerable<Installer> _installers = Enumerable.Empty<Installer>();

        public static WindsorInstallers Builder()
        {
            return new WindsorInstallers();
        }

        private WindsorInstallers Assign(Installer installer)
        {
            return Assign(new[] { installer });
        }

        private WindsorInstallers Assign(IEnumerable<Installer> installers)
        {
            _installers = _installers.Union(installers).ToArray();
            return this;
        }

        public WindsorInstallers Include<T>() where T : IWindsorInstaller, new()
        {
            return Assign(Installer.Create<T>(() => new T()));
        }

        public WindsorInstallers Include<T, TAs>()
            where T : IWindsorInstaller, new()
            where TAs : class, IWindsorInstaller
        {
            return Assign(Installer.Create<TAs>(() => new T()));
        }

        public WindsorInstallers Include(Assembly assembly)
        {
            var assemblyInstallers = assembly.GetTypes()
                .Where(t => typeof(IWindsorInstaller).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .Where(t => !_installers.Any(i => i.InstallerType.IsAssignableFrom(t)))
                .Select(t => Installer.Create(t, () => (IWindsorInstaller)Activator.CreateInstance(t)));

            return Assign(assemblyInstallers);
        }

        public WindsorInstallers OrderFirst<T>() where T : IWindsorInstaller
        {
            _installers = _installers.OrderBy(installer => !(installer.InstallerType == typeof(T))).ToArray();
            return this;
        }

        public IEnumerable<IWindsorInstaller> Build()
        {
            return _installers.Select(i => i.Create());
        }

        public static implicit operator IWindsorInstaller[] (WindsorInstallers installers)
        {
            return installers.Build().ToArray();
        }
    }
}
