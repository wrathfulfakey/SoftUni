namespace SulsApp
{
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.MvcFramework;
    using SulsApp.Controllers;

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
        }

        public void ConfigureServices()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
