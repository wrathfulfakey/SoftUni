namespace SIS.MvcFramework
{
    using System.Collections.Generic;

    using SIS.HTTP;

    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);

        void ConfigureServices(IServiceCollection serviceCollection);
    }
}
