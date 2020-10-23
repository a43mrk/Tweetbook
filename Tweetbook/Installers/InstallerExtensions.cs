using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tweetbook.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            // Get all classes that implements IInstaller on the Startup Assembly
            // get their instances and cast into IInstaller list
            // them call InstallServices for each instance.
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where( x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach( installer => installer.InstallServices(services, configuration));
        }
    }
}